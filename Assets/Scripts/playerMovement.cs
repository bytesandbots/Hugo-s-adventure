using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerMovement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float runSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private float currentSpeed;
    public float lerpSpeed = 7;
    public  Animator anim;
    public Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        currentSpeed = speed;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;   

    }

    void Update()
    {
        float oldy = moveDirection.y;
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection = Camera.main.transform.GetChild(0).TransformDirection(moveDirection);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, lerpSpeed * Time.deltaTime);
        }
        else {
            currentSpeed = Mathf.MoveTowards(currentSpeed, speed, lerpSpeed * Time.deltaTime);
        }

        moveDirection *= currentSpeed;
        if (characterController.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        else{
            moveDirection.y = oldy;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);


        Vector3 noY = moveDirection;
        noY.y = 0.0f;
        anim.SetFloat("Speed", noY.magnitude);
    }
}

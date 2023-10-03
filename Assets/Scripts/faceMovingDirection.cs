using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class faceMovingDirection : MonoBehaviour
{
    public float lerpSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentDirection = GetComponentInParent<playerMovement>().moveDirection;
        currentDirection.y = 0;
        if (currentDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(currentDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, lerpSpeed * Time.deltaTime);

            Vector3 yay = transform.localEulerAngles;
            yay.z = 0;
            yay.x = 0;

            transform.localEulerAngles = yay;
        }
    }
}

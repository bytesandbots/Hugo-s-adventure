using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform CameraTarget;
    private float x = 0.0f;
    private float y = 0.0f;

    public float mouseXSpeedMod = 2.5f;
    public float mouseYSpeedMod = 2.5f;

    public float MaxViewDistance = 15f;
    public float MinViewDistance = 1f;
    public int ZoomRate = 20;
    private float distance = 3f;
    private float desireDistance;
    private float correctedDistance;
    private float currentDistance;

    public float cameraTargetHeight = 1.0f;
    public LayerMask ignoreLayer;


    // Use this for initialization
    void Start()
    {
        Vector3 Angles = transform.eulerAngles;
        x = Angles.x;
        y = Angles.y;
        currentDistance = distance;
        desireDistance = distance;
        correctedDistance = distance;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        x += Input.GetAxis("Mouse X") * mouseXSpeedMod;
        y -= Input.GetAxis("Mouse Y") * mouseYSpeedMod;


        y = ClampAngle(y, -15, 25);
        Quaternion rotation = Quaternion.Euler(y, x, 0);

        desireDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * ZoomRate * Mathf.Abs(desireDistance);
        desireDistance = Mathf.Clamp(desireDistance, MinViewDistance, MaxViewDistance);
        correctedDistance = desireDistance;

        Vector3 position = CameraTarget.position - (rotation * Vector3.forward * desireDistance);

        RaycastHit collisionHit;
        Vector3 cameraTargetPosition = new Vector3(CameraTarget.position.x, CameraTarget.position.y + cameraTargetHeight, CameraTarget.position.z);

        bool isCorrected = false;
        if (Physics.Linecast(cameraTargetPosition, position, out collisionHit,ignoreLayer))
        {
            position = collisionHit.point;
            correctedDistance = Vector3.Distance(cameraTargetPosition, position);
            isCorrected = true;
        }

        //?
        //condicion ? first_expresion : second_expresion;
        //(input > 0) ? isPositive : isNegative;

        currentDistance = !isCorrected || correctedDistance > currentDistance ? Mathf.Lerp(currentDistance, correctedDistance, Time.deltaTime * ZoomRate) : correctedDistance;

        position = CameraTarget.position - (rotation * Vector3.forward * currentDistance + new Vector3(0, -cameraTargetHeight, 0));

        transform.rotation = rotation;
        transform.position = position;

        //CameraTarget.rotation = rotation;

       // float cameraX = transform.rotation.x;
        //checks if right mouse button is pushed
       // if (Input.GetMouseButton(1))
       // {
            //sets CHARACTERS x rotation to match cameras x rotation
       //     CameraTarget.eulerAngles = new Vector3(cameraX, transform.eulerAngles.y, transform.eulerAngles.z);
       // }


    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
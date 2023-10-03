using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeYZRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempRot = transform.eulerAngles;
        tempRot.x = 0;
        tempRot.z = 0;

        transform.eulerAngles = tempRot; 
    }
}

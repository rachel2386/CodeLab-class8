using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

//usage: put on your main camera
//purpose: camera control techniques 
//like simple mouse look/ following a target
public class CameraDemo : MonoBehaviour
{
    // Update is called once per frame
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //simple mouse look
        //1. get mouse input
        float horizontalMouseSpeed = Input.GetAxis("Mouse X");
        float verticalMouseSpeed = Input.GetAxis("Mouse Y");

       //2. use mouse input to rotate camera,
        transform.Rotate(0f, horizontalMouseSpeed, 0f);
        transform.Rotate(-verticalMouseSpeed, 0f, 0f);
        //3. unroll the camera, set it's z to 0f
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
    }
}
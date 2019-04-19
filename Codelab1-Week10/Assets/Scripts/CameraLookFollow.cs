using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookFollow : MonoBehaviour
{
    public Transform LookTarget;
    void Update()
    {
        if(LookTarget == null)
            return;
        
        //technique 1: use Lookat
            // transform.LookAt(LookTarget);
        //technique 2: use Quaternions to make the thing look at the thing
            Vector3 forward = LookTarget.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(forward);
            //more mechanical feel
                //transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,30f* Time.deltaTime);
            //more organic feel
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);

    }
}


using UnityEngine;

public class RayCastButton : MonoBehaviour
{
    private Vector3 initPos;

    private Transform eyePos;
    private Transform mouthPos;

    private GameObject playerAvatar;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        eyePos = GameObject.Find("EyePos").transform;
        mouthPos = GameObject.Find("MouthPos").transform;
        playerAvatar = GameObject.Find("Avatar");
    }

    // Update is called once per frame
    void Update()
    {
        
        //step1 generate a ray variable
        Ray myRay = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(myRay.origin,myRay.direction * 1000f, Color.red);
        //initialize raycasthit variable
        RaycastHit hitInfo = new RaycastHit();
        
       //shoot ray
      
       if(Input.GetMouseButtonDown(0))
       if (Physics.Raycast(myRay, out hitInfo, 1000f))
       {
           if (hitInfo.transform.gameObject.CompareTag("Player"))
           {
               hitInfo.transform.Rotate(0,90,0);
           }

           if (hitInfo.transform.gameObject.CompareTag("FaceColors"))
           {
               playerAvatar.GetComponent<Renderer>().material.color = hitInfo.transform.gameObject.GetComponent<Renderer>().material.color;
           }

           if (hitInfo.transform.gameObject.CompareTag("FaceShape"))
           {
               Debug.Log("clicked" + hitInfo.transform.gameObject.name);
               playerAvatar.GetComponent<MeshFilter>().mesh = hitInfo.transform.gameObject.GetComponent<MeshFilter>().sharedMesh;
           }
           
           if (hitInfo.transform.gameObject.CompareTag("Eyes"))
           {
               initPos = hitInfo.transform.position;
               if (eyePos.childCount >= 1)
               {
                   eyePos.GetChild(0).position = initPos;
                   eyePos.GetChild(0).parent = null;
               }
           
               hitInfo.transform.parent = eyePos;
               hitInfo.transform.localPosition = Vector3.zero;

           }
           if (hitInfo.transform.gameObject.CompareTag("Mouth"))
           {
               initPos = hitInfo.transform.position;
               if (mouthPos.childCount >= 1)
               {
                   mouthPos.GetChild(0).position = initPos;
                   mouthPos.GetChild(0).parent = null;
               }
           
               hitInfo.transform.parent = mouthPos;
               hitInfo.transform.localPosition = Vector3.zero;

           }
       }

    }

    private void OnMouseDown()
    {

        //ref to the gameObject you put the script on
    }
}

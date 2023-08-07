using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouse : MonoBehaviour
{
    Camera mainCam;
 
    void Start()
    {
        mainCam = GameObject.FindObjectOfType<Camera>();

        Cursor.visible = false;
    }

    void Update()
    {
        Ray camRay = mainCam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(camRay.origin, camRay.direction*1000, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(camRay,out hit,1000,1<<3))
        {
            Vector3 pointToLook = hit.point;


            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}

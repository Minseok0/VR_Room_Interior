using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_ChangeView : MonoBehaviour
{
    private Transform XR_Origin;
    private Vector3 cameraDirection;

    private void Start()
    {
        if(XR_Origin == null) {
            XR_Origin = GameObject.Find("XR Origin").transform;
        }

    }
    public void MoveBackward()
    {
        cameraDirection = (-Camera.main.transform.forward) * 5.0f; //  + Camera.main.transform.up
        XR_Origin.transform.position += cameraDirection;
    }
    public void MoveForward()
    {
        cameraDirection = (Camera.main.transform.forward ) * 5.0f; //- Camera.main.transform.up
        XR_Origin.transform.position += cameraDirection;
    }

}

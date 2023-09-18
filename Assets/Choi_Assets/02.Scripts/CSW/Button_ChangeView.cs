using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_ChangeView : MonoBehaviour
{
    public Transform XR_RigTr;
    public Vector3 cameraDirection;
    public void MoveBackward()
    {
        cameraDirection = (-Camera.main.transform.forward) * 5.0f; //  + Camera.main.transform.up
        XR_RigTr.transform.position += cameraDirection;
    }
    public void MoveForward()
    {
        cameraDirection = (Camera.main.transform.forward ) * 5.0f; //- Camera.main.transform.up
        XR_RigTr.transform.position += cameraDirection;
    }

}

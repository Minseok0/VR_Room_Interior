using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class HeightSetting : MonoBehaviour
{
    [SerializeField] Transform cameraOffset;

    private void Start()
    {
        if (cameraOffset == null)
            cameraOffset = transform.root.Find("CameraOffset");
    }

    public void SetHeight(float h)
    {
        cameraOffset.transform.position = new Vector3(cameraOffset.position.x, h, cameraOffset.position.z);
    }
}

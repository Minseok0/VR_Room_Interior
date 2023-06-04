using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_MoveToCreateRoom : MonoBehaviour
{
    public Data_FloorCreatePlane data_FloorCreatePlane; // Inspector���� �����������

    public Transform XR_RigTr; // �÷��̾� ĳ���� transform
    public Transform floorCreatePlaneTr; // �ٴڸ� �۾��� transform

    private void Start()
    {
        XR_RigTr = this.transform.root.Find("XR Rig");
        data_FloorCreatePlane.floorCreatePlanePosition = floorCreatePlaneTr.position;
    }

    public void MoveToWorkPlace()
    {

        data_FloorCreatePlane.originalPlayerPosition = XR_RigTr.position;
        data_FloorCreatePlane.originalPlayerRotation = XR_RigTr.rotation;

        XR_RigTr.SetPositionAndRotation(data_FloorCreatePlane.floorCreatePlanePosition + Vector3.up * 10, Quaternion.Euler(90, 0, 0));

        this.gameObject.SetActive(false);

    }
}

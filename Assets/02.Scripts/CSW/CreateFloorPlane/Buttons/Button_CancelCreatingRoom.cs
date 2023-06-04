using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_CancelCreatingRoom : MonoBehaviour
{
    public Data_FloorCreatePlane data_FloorCreatePlane;

    //public Transform floorCreatePlaneTr; // �ٴڸ� �۾��� transform
    public Transform XR_RigTr; // �÷��̾� ĳ���� transform

    public GameObject createNewFloorButton;

    public void Cancel()
    {
        // data_FloorCreatePlane �����͵� �ʱ�ȭ
        data_FloorCreatePlane.newVertices.Clear();

        data_FloorCreatePlane.lineRenderer.positionCount = 0;

        foreach (GameObject obj in data_FloorCreatePlane.verticesToDestroy)
            Destroy(obj);
        data_FloorCreatePlane.verticesToDestroy.Clear();

        // �÷��̾� ����ġ
        XR_RigTr.SetPositionAndRotation(data_FloorCreatePlane.originalPlayerPosition, data_FloorCreatePlane.originalPlayerRotation);

        createNewFloorButton.SetActive(true);

        Debug.Log("Button_Cancel.Cancel()");
    }
}

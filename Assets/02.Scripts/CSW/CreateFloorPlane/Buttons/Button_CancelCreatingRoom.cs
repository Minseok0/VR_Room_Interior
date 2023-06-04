using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_CancelCreatingRoom : MonoBehaviour
{
    public Data_FloorCreatePlane data_FloorCreatePlane;

    //public Transform floorCreatePlaneTr; // 바닥면 작업대 transform
    public Transform XR_RigTr; // 플레이어 캐릭터 transform

    public GameObject createNewFloorButton;

    public void Cancel()
    {
        // data_FloorCreatePlane 데이터들 초기화
        data_FloorCreatePlane.newVertices.Clear();

        data_FloorCreatePlane.lineRenderer.positionCount = 0;

        foreach (GameObject obj in data_FloorCreatePlane.verticesToDestroy)
            Destroy(obj);
        data_FloorCreatePlane.verticesToDestroy.Clear();

        // 플레이어 원위치
        XR_RigTr.SetPositionAndRotation(data_FloorCreatePlane.originalPlayerPosition, data_FloorCreatePlane.originalPlayerRotation);

        createNewFloorButton.SetActive(true);

        Debug.Log("Button_Cancel.Cancel()");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_ResetCreatingRoom : MonoBehaviour
{
    public Data_FloorCreatePlane data_FloorCreatePlane;

    public void Reset()
    {
        data_FloorCreatePlane.newVertices.Clear();
        data_FloorCreatePlane.lineRenderer.positionCount = 0;

        foreach (GameObject obj in data_FloorCreatePlane.verticesToDestroy)
            Destroy(obj);

        data_FloorCreatePlane.verticesToDestroy.Clear();

        Debug.Log("Button_Reset.Reset()");

    }
}

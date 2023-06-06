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
        data_FloorCreatePlane.lineLengths.Clear();

        for (int i = 0; i < data_FloorCreatePlane.verticesToDestroy.Count; i++)
            Destroy(data_FloorCreatePlane.verticesToDestroy[i]);

        data_FloorCreatePlane.verticesToDestroy.Clear();

        for (int i = 0; i < data_FloorCreatePlane.lengthTextsToDestroy.Count; i++)
            Destroy(data_FloorCreatePlane.lengthTextsToDestroy[i]);

        data_FloorCreatePlane.lengthTextsToDestroy.Clear();

        Debug.Log("Button_Reset.Reset()");
    }
}

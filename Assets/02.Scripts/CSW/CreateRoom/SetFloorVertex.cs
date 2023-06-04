using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class SetFloorVertex : MonoBehaviour
{
    
    public XRRayInteractor rayInteractor_right;
    
    public Data_FloorCreatePlane data_FloorCreatePlane;
    
    public Material vertexMaterial;

    //public Text

    // Start is called before the first frame update
    void Start()
    {

        rayInteractor_right = GameObject.Find("RightHand Controller").GetComponent<XRRayInteractor>();

        data_FloorCreatePlane.floorCreatePlane = this.gameObject;

        data_FloorCreatePlane.newVertices = new List<Vector3>();

        data_FloorCreatePlane.lineRenderer = transform.GetComponent<LineRenderer>();
        data_FloorCreatePlane.lineRenderer.loop = true;

        data_FloorCreatePlane.verticesToDestroy = new List<GameObject>();

    }

    public void SetNewVertex()
    {
        
        bool hitResult = rayInteractor_right.TryGetCurrent3DRaycastHit(out RaycastHit hitInfo);

        if (hitResult)
        {

            Debug.Log("hit position = " + hitInfo.point);


            GameObject newPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            newPoint.name = "vertex_" + data_FloorCreatePlane.newVertices.Count;
            newPoint.transform.position = hitInfo.point;
            newPoint.transform.localScale = new Vector3(0.05f, 0.0f, 0.05f);
            newPoint.GetComponent<MeshRenderer>().material = vertexMaterial;

            newPoint.transform.SetParent(this.gameObject.transform);

            data_FloorCreatePlane.verticesToDestroy.Add(newPoint); // cancel �� �����ؾ��� object

            // newPosition.y = 0.0f;
            data_FloorCreatePlane.newVertices.Add(newPoint.transform.position); // hitInfo.point


            data_FloorCreatePlane.lineRenderer.positionCount = data_FloorCreatePlane.newVertices.Count;
            data_FloorCreatePlane.lineRenderer.SetPosition(data_FloorCreatePlane.lineRenderer.positionCount-1, hitInfo.point+Vector3.up*0.05f);

            // lineLengthCalculator.Calculate();
        }
    }

    public void Calculate()
    {
        if (data_FloorCreatePlane.lineRenderer.positionCount < 2)
            return;

        // LineRenderer에서 길이를 계산할 선분의 위치들을 가져옴
        Vector3[] positions = new Vector3[data_FloorCreatePlane.lineRenderer.positionCount];
        data_FloorCreatePlane.lineRenderer.GetPositions(positions);

        // 각 선분의 길이를 계산
        float[] segmentLengths = new float[data_FloorCreatePlane.lineRenderer.positionCount - 1];

        for (int i = 0; i < data_FloorCreatePlane.lineRenderer.positionCount - 1; i++)
        {
            float segmentLength = Vector3.Distance(positions[i], positions[i + 1]);
            segmentLengths[i] = segmentLength;
        }

        // 결과 출력
        Debug.Log("Segment Lengths:");
        for (int i = 0; i < segmentLengths.Length; i++)
        {
            Debug.Log("Segment " + (i + 1) + ": " + segmentLengths[i]);
        }
    }

}

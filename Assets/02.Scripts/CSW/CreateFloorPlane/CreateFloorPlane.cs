using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CreateFloorPlane : MonoBehaviour
{
    public XRRayInteractor rayInteractor_right;
    
    public Data_FloorCreatePlane data_FloorCreatePlane;
    
    public Material vertexMaterial;

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

            data_FloorCreatePlane.verticesToDestroy.Add(newPoint); // cancel 시 삭제해야할 object

            // newPosition.y = 0.0f;
            data_FloorCreatePlane.newVertices.Add(newPoint.transform.position); // hitInfo.point


            data_FloorCreatePlane.lineRenderer.positionCount = data_FloorCreatePlane.newVertices.Count;
            data_FloorCreatePlane.lineRenderer.SetPosition(data_FloorCreatePlane.lineRenderer.positionCount-1, hitInfo.point+Vector3.up*0.1f);

        }
    }

}

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
    public GameObject lengthTextPrefab;

    public List<GameObject> lengthTextToDestroy;

    bool isHovering;

    // Start is called before the first frame update
    void Start()
    {
        if(rayInteractor_right ==null)
            rayInteractor_right = GameObject.Find("Right Ray Interactor").GetComponent<XRRayInteractor>();

        data_FloorCreatePlane.floorCreatePlane = this.gameObject;

        data_FloorCreatePlane.newVertices = new List<Vector3>();

        data_FloorCreatePlane.lineRenderer = transform.GetComponent<LineRenderer>();
        data_FloorCreatePlane.lineRenderer.loop = true;

        data_FloorCreatePlane.verticesToDestroy = new List<GameObject>();

        data_FloorCreatePlane.lengthTextsToDestroy = new List<GameObject>();

    }

    private void NewPointSetting(GameObject _newPoint)
    {
        _newPoint.GetComponent<MeshRenderer>().material = vertexMaterial;
        _newPoint.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        
    }

    public void HoverEntered_NewVertex()
    {
        isHovering = true;

        bool hitResult = rayInteractor_right.TryGetCurrent3DRaycastHit(out RaycastHit hitInfo);
        if(hitResult && hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("DRAWABLE"))
        {
            data_FloorCreatePlane.lineRenderer.positionCount++;
            //data_FloorCreatePlane.lineRenderer.SetPosition(data_FloorCreatePlane.lineRenderer.positionCount - 1, hitInfo.point + Vector3.up * 0.0001f);

            StartCoroutine(HoveringNewVertex());
        }
    }

    IEnumerator HoveringNewVertex()
    {
        while(isHovering){
            if (data_FloorCreatePlane.newVertices.Count < 1)
                yield return new WaitForSeconds(0.1f);
            else
            {
                bool hitResult = rayInteractor_right.TryGetCurrent3DRaycastHit(out RaycastHit hitInfo);

                if (hitResult && hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("DRAWABLE"))
                {
                    data_FloorCreatePlane.lineRenderer.SetPosition(data_FloorCreatePlane.lineRenderer.positionCount - 1, hitInfo.point + Vector3.up * 0.0001f);

                    LengthCalculate_Hover();
                }
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    public void HoverExited_NewVertex()
    {
        isHovering = false;

        StopCoroutine(HoveringNewVertex());
        data_FloorCreatePlane.lineRenderer.positionCount--;

        LengthCalculate_Select();
    }

    private void LengthCalculate_Hover()
    {
        int positionCnt = data_FloorCreatePlane.lineRenderer.positionCount;
        if (positionCnt < 2)
            return;

        for (int i = 0; i < data_FloorCreatePlane.lengthTextsToDestroy.Count; i++)
            Destroy(data_FloorCreatePlane.lengthTextsToDestroy[i]);

        data_FloorCreatePlane.lineLengths.Clear();
        data_FloorCreatePlane.lengthTextsToDestroy.Clear();

        Vector3[] positions = new Vector3[positionCnt];
        data_FloorCreatePlane.lineRenderer.GetPositions(positions);

        for (int i = 0; i < positionCnt; i++)
        {
            float segmentLength = Vector3.Distance(positions[i % positionCnt], positions[(i + 1) % positionCnt]);
            segmentLength = (Mathf.Round(segmentLength * 1000f) / 1000f) * 1000;

            // 각 점에 텍스트를 생성하여 길이 표시
            GameObject lengthText = Instantiate(lengthTextPrefab);
            lengthText.transform.position = ((positions[i % positionCnt] + positions[(i + 1) % positionCnt]) / 2f);
           
            TextMesh textMesh = lengthText.GetComponent<TextMesh>();
            textMesh.text = segmentLength.ToString();

            data_FloorCreatePlane.lineLengths.Add(segmentLength);

            data_FloorCreatePlane.lengthTextsToDestroy.Add(lengthText);
        }
    }

    public void SelectNewVertex()
    {
        bool hitResult = rayInteractor_right.TryGetCurrent3DRaycastHit(out RaycastHit hitInfo);
        if (hitResult == false)
            return;
        if(hitInfo.transform.GetComponent<SetFloorVertex>() == false)
            return;

        GameObject newPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        NewPointSetting(newPoint);
        newPoint.transform.position = hitInfo.point;

        data_FloorCreatePlane.verticesToDestroy.Add(newPoint);

        // newPosition.y = 0.0f;
        data_FloorCreatePlane.newVertices.Add(newPoint.transform.position); // hitInfo.point

        // data_FloorCreatePlane.lineRenderer.positionCount = data_FloorCreatePlane.newVertices.Count;
        data_FloorCreatePlane.lineRenderer.SetPosition(data_FloorCreatePlane.lineRenderer.positionCount-1, hitInfo.point+Vector3.up*0.0001f);

        data_FloorCreatePlane.lineRenderer.positionCount++;

        LengthCalculate_Select();

    }

    private void LengthCalculate_Select()
    {
        int positionCnt = data_FloorCreatePlane.lineRenderer.positionCount;
        if (positionCnt < 2)
            return;

        for (int i = 0; i < data_FloorCreatePlane.lengthTextsToDestroy.Count; i++)
            Destroy(data_FloorCreatePlane.lengthTextsToDestroy[i]);

        data_FloorCreatePlane.lineLengths.Clear();
        data_FloorCreatePlane.lengthTextsToDestroy.Clear();

        Vector3[] positions = new Vector3[positionCnt];
        data_FloorCreatePlane.lineRenderer.GetPositions(positions);

        for (int i = 0; i < positionCnt; i++)
        {
            float segmentLength = Vector3.Distance(positions[i%positionCnt], positions[(i + 1)%positionCnt]);
            //segmentLengths[i] = segmentLength;

            // 각 점에 텍스트를 생성하여 길이 표시
            GameObject lengthText = Instantiate(lengthTextPrefab);
            lengthText.transform.position = ((positions[i % positionCnt] + positions[(i + 1) % positionCnt]) / 2f);
            //lengthText.transform.rotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
            segmentLength = (Mathf.Round(segmentLength * 1000f) / 1000f) * 1000;

            TextMesh textMesh = lengthText.GetComponent<TextMesh>();
            textMesh.text = segmentLength.ToString(); 

            data_FloorCreatePlane.lineLengths.Add(segmentLength);
            
            data_FloorCreatePlane.lengthTextsToDestroy.Add(lengthText);
        }
    }

    // public void VecticesLinesClear()
    // {
    //     for (int i = 0; i < data_FloorCreatePlane.verticesToDestroy.Count; i++)
    //         Destroy(data_FloorCreatePlane.verticesToDestroy[i]);
    //     data_FloorCreatePlane.verticesToDestroy.Clear();

    //     for (int i = 0; i < data_FloorCreatePlane.lengthTextsToDestroy.Count; i++)
    //         Destroy(data_FloorCreatePlane.lengthTextsToDestroy[i]);
    //     data_FloorCreatePlane.lengthTextsToDestroy.Clear();

    //     data_FloorCreatePlane.newVertices.Clear();
    //     data_FloorCreatePlane.lineLengths.Clear();

    //     data_FloorCreatePlane.lineRenderer.positionCount = 0;
    // }
}

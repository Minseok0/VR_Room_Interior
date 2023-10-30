using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit;


public class Button_CompleteCreatingRoom : MonoBehaviour
{
    [SerializeField] private Transform XR_OriginTr;
    [SerializeField] private GameObject createNewFloorButton;

    [Header("생성 경로")]
    [SerializeField]
    private string createdFloor_MeshPath;
    [SerializeField]
    private string createdFloor_PrefabPath;
    [SerializeField]
    private string createdCeiling_MeshPath;
    [SerializeField]
    private string createdCeiling_PrefabPath;

    [SerializeField]
    private string createdRooom_PrefabPath;

    [Space(10)]
    [SerializeField]
    private Data_RoomCount data_RoomCount;
    [SerializeField]
    private Data_FloorCreatePlane data_FloorCreatePlane;

    private GameObject roomObject;
    private GameObject floorObject;
    //public GameObject ceilingObject;
    //public Material ceilingMat;
    [Space(10)]
    public GameObject wallPrefab;

    private Vector3 newFloorCenter; // , newCeilingCenter

    public List<int> triangles;

    private Mesh mesh;
    private MeshFilter meshFilter;
    private MeshCollider meshCollider;
    private MeshRenderer meshRenderer;

    public float wallHeight;

    private List<Vector3> newVertices_translated;

    //https://bloodstrawberry.tistory.com/996

    private void Awake()
    {
        if(XR_OriginTr == null)
        {
            XR_OriginTr = GameObject.Find("XR Origin").transform;
        }
    }

    // 새로운 Mesh 생성 후 prefab으로 저장
    private void CreateNewRoomPrefab()
    {
        roomObject = new GameObject("CreatedRoom " + data_RoomCount.roomCount);

        CreateFloor();

        CreateWalls(newVertices_translated);

        CreateCeiling();

        PrefabUtility.SaveAsPrefabAssetAndConnect(roomObject, createdRooom_PrefabPath + roomObject.name + ".prefab", InteractionMode.UserAction, out bool success);
        data_RoomCount.roomCount++;

        //Destroy(roomObject);
        roomObject.transform.SetPositionAndRotation(data_FloorCreatePlane.originalPlayerPosition, data_FloorCreatePlane.originalPlayerRotation);

        XR_OriginTr.SetPositionAndRotation(data_FloorCreatePlane.originalPlayerPosition, data_FloorCreatePlane.originalPlayerRotation);
        createNewFloorButton.SetActive(true);
    }

    // 주어진 정점a b c을 순서대로 clock wise인지 확인
    bool CWby2D(Vector3 a, Vector3 b, Vector3 c)
    {
        Vector3 p = b - a;
        Vector3 q = c - b;

        if (Vector3.Cross(p, q).y > 0)
            return true;
        else
            return false;
    }

    void MakeTriangle(List<int> triangles, int s, int m, int e)
    {
        triangles.Add(s);
        triangles.Add(m);
        triangles.Add(e);
    }

    float GetAreaOfTriangle(Vector3 dot1, Vector3 dot2, Vector3 dot3)
    {
        Vector3 a = dot2 - dot1;
        Vector3 b = dot3 - dot1;
        Vector3 cross = Vector3.Cross(a, b);

        return cross.magnitude / 2.0f;
    }

    // triangle안에 point가 있는지 확인
    bool CheckTriangleInPoint(Vector3 dot1, Vector3 dot2, Vector3 dot3, Vector3 checkPoint)
    {
        if (dot1 == checkPoint) return false;
        if (dot2 == checkPoint) return false;
        if (dot3 == checkPoint) return false;

        float dot123_area = GetAreaOfTriangle(dot1, dot2, dot3);
        float dot12_area = GetAreaOfTriangle(dot1, dot2, checkPoint);
        float dot23_area = GetAreaOfTriangle(dot2, dot3, checkPoint);
        float dot31_area = GetAreaOfTriangle(dot3, dot1, checkPoint);

        return (dot12_area + dot23_area + dot31_area) <= dot123_area + 0.1f /* 오차 허용 */;
    }

    bool CrossCheckAll(List<Vector3> newVertices, int startIndex, int midIndex, int endIndex)
    {
        Vector3 startVertex = newVertices[startIndex];
        Vector3 midVertex = newVertices[midIndex];
        Vector3 endVertex = newVertices[endIndex];

        for (int i = 0; i < data_FloorCreatePlane.newVertices.Count; i++)
        {
            if (CheckTriangleInPoint(startVertex, midVertex, endVertex, newVertices[i]) == true) return true;
        }

        return false;
    }

    void PolygonTriangulation()
    {
        int numOfTriangle = data_FloorCreatePlane.newVertices.Count - 2;
        int start, mid, end;
        HashSet<int> usedVertices = new();

        for (int i = 0; i < numOfTriangle; i++)
        {
            for (int k = 0; k < data_FloorCreatePlane.newVertices.Count; k++)
            {
                start = k;
                while (usedVertices.Contains(start % data_FloorCreatePlane.newVertices.Count)) // triangle의 midVertex로 사용하지 않은 점인지 
                    start++;
                start %= data_FloorCreatePlane.newVertices.Count;

                mid = start + 1;
                while (usedVertices.Contains(mid % data_FloorCreatePlane.newVertices.Count)) // triangle의 midVertex로 사용하지 않은 점인지 
                    mid++;
                mid %= data_FloorCreatePlane.newVertices.Count;
                
                end = mid + 1;
                while (usedVertices.Contains(end % data_FloorCreatePlane.newVertices.Count)) // triangle의 midVertex로 사용하지 않은 점인지 
                    end++;
                end %= data_FloorCreatePlane.newVertices.Count;


                bool cw = (CWby2D(data_FloorCreatePlane.newVertices[start], data_FloorCreatePlane.newVertices[mid], data_FloorCreatePlane.newVertices[end]));
                bool cross = CrossCheckAll(data_FloorCreatePlane.newVertices, start, mid, end);

                // cw방향 _ 유니티는 왼손좌표계임. 따라서 clock-wise로 정점들의 순서가 주어져야 위에서 아래로 볼 때 렌더링 됨.
                if (cw && !cross) // 
                {
                    MakeTriangle(triangles, start, mid, end); // start, mid, end

                    usedVertices.Add(mid); // mid vertex 재사용 막음

                    break;
                }

            }
        }

        if( (triangles.Count/3) != numOfTriangle)
        {
            triangles.Clear();
            usedVertices.Clear();
            data_FloorCreatePlane.newVertices.Reverse();

            for (int i = 0; i < numOfTriangle; i++)
            {
                for (int k = 0; k < data_FloorCreatePlane.newVertices.Count; k++)
                {
                    start = k;
                    while (usedVertices.Contains(start % data_FloorCreatePlane.newVertices.Count)) // triangle의 midVertex로 사용하지 않은 점인지 
                        start++;
                    start %= data_FloorCreatePlane.newVertices.Count;

                    mid = start + 1;
                    while (usedVertices.Contains(mid % data_FloorCreatePlane.newVertices.Count)) // triangle의 midVertex로 사용하지 않은 점인지 
                        mid++;
                    mid %= data_FloorCreatePlane.newVertices.Count;


                    end = mid + 1;
                    while (usedVertices.Contains(end % data_FloorCreatePlane.newVertices.Count)) // triangle의 midVertex로 사용하지 않은 점인지 
                        end++;
                    end %= data_FloorCreatePlane.newVertices.Count;


                    bool cw = (CWby2D(data_FloorCreatePlane.newVertices[start], data_FloorCreatePlane.newVertices[mid], data_FloorCreatePlane.newVertices[end]));
                    bool cross = CrossCheckAll(data_FloorCreatePlane.newVertices, start, mid, end);

                    // cw방향 _ 유니티는 왼손좌표계임. 따라서 clock-wise로 정점들의 순서가 주어져야 위에서 아래로 볼 때 렌더링 됨.
                    if (cw && !cross) // 
                    {
                        MakeTriangle(triangles, start, mid, end); // start, mid, end

                        usedVertices.Add(mid); // mid vertex 재사용 막음

                        break;
                    }

                }
            }
        }
    }

    // floor - 바닥면
    private void CreateFloor()
    {
        newVertices_translated = new();


        floorObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floorObject.name = "CreatedFloor " + data_RoomCount.roomCount;

        newFloorCenter = Vector3.zero;
        mesh = new Mesh();
        mesh.name = "CreatedFloorMesh " + data_RoomCount.roomCount;

        //Debug.Log("data_FloorCreatePlane.newVertices.Count = " + data_FloorCreatePlane.newVertices.Count);
        foreach (var v in data_FloorCreatePlane.newVertices)
            newFloorCenter += v;
        newFloorCenter /= data_FloorCreatePlane.newVertices.Count;


        foreach (var v in data_FloorCreatePlane.newVertices)
            newVertices_translated.Add(v - newFloorCenter); // createFloorPlane의 위치에 대한 상대적인 위치

        mesh.vertices = newVertices_translated.ToArray();

        mesh.triangles = triangles.ToArray();
        //mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        // createdFloor_mesh save
        AssetDatabase.CreateAsset(mesh, createdFloor_MeshPath + mesh.name + ".asset");

        meshFilter = floorObject.GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        meshCollider = floorObject.GetComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;

        floorObject.transform.position += new Vector3(0.0f, 0.0001f, 0.0f);

        floorObject.AddComponent<TeleportationArea>();

        PrefabUtility.SaveAsPrefabAsset(floorObject, createdFloor_PrefabPath + floorObject.name + ".prefab");
        //floorObject.AddComponent<Teleportation
        // floorObject is room object's child.
        floorObject.transform.SetParent(roomObject.transform);

        floorObject.AddComponent<TeleportationArea>();
        floorObject.GetComponent<TeleportationArea>().interactionLayers |= 1 << 31;
    }

    // walls _ 벽 생성
    private void CreateWalls(List<Vector3> newVertices)
    {
        int wallCount = newVertices.Count; // # of walls == # of vertices
        Vector3 wallPosition;
        for (int i=0; i< wallCount; i++)
        {
            Vector3 currentPoint = newVertices[i];
            Vector3 nextPoint = newVertices[(i + 1) % newVertices.Count]; // 다음 점 (마지막 점일 경우 첫 번째 점으로 연결)

            // 벽의 위치 계산 (점과 점 사이의 중간 지점)
            wallPosition = (currentPoint + nextPoint) / 2f;
            // 벽의 높이로 y 좌표를 조절
            wallPosition.y = wallHeight/2; 

            // 벽의 회전 계산 (점과 점 사이의 방향 벡터를 이용)
            Quaternion wallRotation = Quaternion.LookRotation(nextPoint - currentPoint, Vector3.up);

            // 벽 생성
            GameObject innerWall = Instantiate(wallPrefab, wallPosition, wallRotation);
            innerWall.name = "InnerWall_" + i;
            innerWall.transform.localScale = new Vector3(0.03f, wallHeight, Vector3.Distance(nextPoint, currentPoint)); // Vector3.Distance(nextPoint, currentPoint
            innerWall.transform.position += new Vector3(-0.01f, 0.0001f, 0.0f);
            // child gameobject
            innerWall.transform.SetParent(roomObject.transform);
            

            // 벽 생성
            GameObject outerWall = Instantiate(wallPrefab, wallPosition, wallRotation);
            outerWall.name = "OuterWall_" + i;
            outerWall.transform.localScale = new Vector3(0.03f, wallHeight, Vector3.Distance(nextPoint, currentPoint)+0.0001f); //Vector3.Distance(nextPoint, currentPoint)
            outerWall.transform.localPosition += new Vector3(0, 0.0001f, 0.0f);
            // child gameobject
            outerWall.transform.SetParent(roomObject.transform);
        }
    }

    // Ceiling _ 천장 생성
    private void CreateCeiling()
    {
        GameObject innerCeiling = GameObject.CreatePrimitive(PrimitiveType.Plane);

        innerCeiling.name = "InnerCeiling " + data_RoomCount.roomCount;

        //newCeilingCenter = Vector3.zero;
        mesh = new Mesh();
        mesh.name = "CreatedCeilingMesh " + data_RoomCount.roomCount;

        mesh.vertices = newVertices_translated.ToArray();

        triangles.Reverse();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();

        // createdFloor_mesh save
        AssetDatabase.CreateAsset(mesh, createdCeiling_MeshPath + mesh.name + ".asset");

        meshFilter = innerCeiling.GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        meshCollider = innerCeiling.GetComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;

        innerCeiling.transform.position += new Vector3(0.0f, wallHeight-0.02f, 0.0f);

        PrefabUtility.SaveAsPrefabAsset(innerCeiling, createdCeiling_PrefabPath + innerCeiling.name + ".prefab");

        // floorObject is room object's child.
        innerCeiling.transform.SetParent(roomObject.transform);

        GameObject outerCeiling = Instantiate(floorObject);
        outerCeiling.name = "OuterCeiling";
        outerCeiling.transform.SetPositionAndRotation(floorObject.transform.position + new Vector3(0.0f, wallHeight, 0.0f),
        floorObject.transform.rotation);
        //outerCeiling.GetComponent<MeshRenderer>().material = ceilingMat;
        outerCeiling.transform.SetParent(roomObject.transform);
        //outerCeiling.transform.localScale += Vector3.one*0.003f;

    }

    // OnClick()
    public void CompleteCreating()
    {
        // Line renderer 
        data_FloorCreatePlane.floorCreatePlane.GetComponent<LineRenderer>().positionCount = 0;

        if (data_FloorCreatePlane.newVertices.Count < 3)
        {
            Debug.Log("vertices 개수가 " + data_FloorCreatePlane.newVertices.Count 
                + "로 3 미만입니다. 새로운 floorplane을 생성할 수 없습니다. ");

            ClearAll();
            return;
        }
        else
            PolygonTriangulation(); // triangles 설정

        CreateNewRoomPrefab();

        ClearAll();

        Debug.Log("Button_Complete.Modify()");
    }

    // modifying 데이터들 clear
    private void ClearAll()
    {
        data_FloorCreatePlane.newVertices.Clear();
        triangles.Clear();
        data_FloorCreatePlane.floorCreatePlane.GetComponent<LineRenderer>().positionCount = 0;
        data_FloorCreatePlane.lineLengths.Clear();

        //newPoint.name = "vertex_" + data_FloorCreatePlane.newVertices.Count;

        for (int i = 0; i < data_FloorCreatePlane.verticesToDestroy.Count; i++)
            Destroy(data_FloorCreatePlane.verticesToDestroy[i]);
        data_FloorCreatePlane.verticesToDestroy.Clear();

        for (int i = 0; i < data_FloorCreatePlane.lengthTextsToDestroy.Count; i++)
            Destroy(data_FloorCreatePlane.lengthTextsToDestroy[i]);
        data_FloorCreatePlane.lengthTextsToDestroy.Clear();
    }
}

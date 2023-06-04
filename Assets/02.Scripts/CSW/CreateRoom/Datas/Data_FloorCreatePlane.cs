using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data_FloorCreatePlane", menuName = "RoomCreate/Data_FloorCreatePlane")]
public class Data_FloorCreatePlane : ScriptableObject
{
    public GameObject floorCreatePlane; // �۾��� plane

    public List<Vector3> newVertices; // ���� ���� ������

    public LineRenderer lineRenderer; // �����鿡 ���� ���� ������

    public List<GameObject> verticesToDestroy;

    public Vector3 originalPlayerPosition; // �۾� ���� player�� ���� ��ġ
    public Quaternion originalPlayerRotation; // �۾� ���� player�� ���� ����

    public Vector3 floorCreatePlanePosition; // �۾� ���� floorCreatePlane ���� ��ġ
   
    
}

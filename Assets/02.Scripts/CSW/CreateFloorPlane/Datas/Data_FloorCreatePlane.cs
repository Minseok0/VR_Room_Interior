using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data_FloorCreatePlane", menuName = "FloorPlane/Data_FloorCreatePlane")]
public class Data_FloorCreatePlane : ScriptableObject
{
    public GameObject floorCreatePlane; // 작업할 plane

    public List<Vector3> newVertices; // 새로 찍은 정점들

    public LineRenderer lineRenderer; // 정점들에 맞춰 생긴 엣지들

    public List<GameObject> verticesToDestroy;

    public Vector3 originalPlayerPosition; // 작업 중인 player의 기존 위치
    public Quaternion originalPlayerRotation; // 작업 중인 player의 기존 방향

    public Vector3 floorCreatePlanePosition; // 작업 중인 floorCreatePlane 기존 위치
   
    
}

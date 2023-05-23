using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlacementChecker : MonoBehaviour
{
    private List<Collider> colliderList; // 충돌한 오브젝트들 저장할 리스트
    public int colliderCnt; // 충돌한 오브젝트들 개수

    public int layerFloor; // 지형 레이어 (무시하게 할 것)
    private const int IGNORE_RAYCAST_LAYER = 2;  // ignore_raycast (무시하게 할 것)

    public Material originalMat;
    public Material RedFurniture;
    
    private void Start()
    {
        layerFloor = 6;
        colliderList = new List<Collider>();
        originalMat = AssetDatabase.LoadAssetAtPath<Material>("Assets/04.Images/Materials/Furniture.mat");
        RedFurniture = AssetDatabase.LoadAssetAtPath<Material>("Assets/04.Images/Materials/RedFurniture.mat");
    }

    private void SetMaterial(Material mat)
    {
        this.GetComponent<Renderer>().material = mat;

        foreach (Transform tr_Child in this.transform)
        {
            Material[] newMaterials = new Material[tr_Child.GetComponent<Renderer>().materials.Length];

            for (int i = 0; i < newMaterials.Length; i++)
            {
                newMaterials[i] = mat;
            }

            tr_Child.GetComponent<Renderer>().materials = newMaterials;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != layerFloor && other.gameObject.layer != IGNORE_RAYCAST_LAYER)
        {
            //colliderList.Add(other);

            colliderCnt++;

            ChangeColor();
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.layer != layerFloor && other.gameObject.layer != IGNORE_RAYCAST_LAYER)
        {
            //colliderList.Remove(other);

            colliderCnt--;

            ChangeColor();
        }        
    }

    private void ChangeColor()
    {
        if (colliderCnt > 0)
            SetMaterial(RedFurniture);
        else
            SetMaterial(originalMat);
    }

}

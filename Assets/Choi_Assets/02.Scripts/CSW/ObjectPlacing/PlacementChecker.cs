using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlacementChecker : MonoBehaviour
{
    private List<Collider> colliderList; // �浹�� ������Ʈ�� ������ ����Ʈ
    public int colliderCnt; // �浹�� ������Ʈ�� ����

    public int layerFloor; // ���� ���̾� (�����ϰ� �� ��)
    private const int IGNORE_RAYCAST_LAYER = 2;  // ignore_raycast (�����ϰ� �� ��)

    public Material originalMat;
    public Material RedFurniture;
    
    private void Start()
    {
        colliderList = new List<Collider>();
        originalMat = this.gameObject.GetComponent<MeshRenderer>().material;
        RedFurniture = AssetDatabase.LoadAssetAtPath<Material>("Assets/04.Images/CSW/Materials/RedFurniture.mat");
    }

    private void SetMaterial(Material mat)
    {
        this.GetComponent<MeshRenderer>().material = mat;

        /*foreach (Transform tr_Child in this.transform)
        {
            Material[] newMaterials = new Material[tr_Child.GetComponent<MeshRenderer>().materials.Length];

            for (int i = 0; i < newMaterials.Length; i++)
            {
                newMaterials[i] = mat;
            }

            tr_Child.GetComponent<MeshRenderer>().materials = newMaterials;
        }*/
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

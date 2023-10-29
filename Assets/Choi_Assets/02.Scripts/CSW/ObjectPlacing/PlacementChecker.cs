using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlacementChecker : MonoBehaviour
{
    //private List<Collider> colliderList; 
    public int colliderCnt; 

    public int layerFloor; 
    private const int IGNORE_RAYCAST_LAYER = 2;  // ignore_raycast 

    public Material originalMat;
    public Material RedFurniture;
    
    private void Start()
    {
        //gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        layerFloor = LayerMask.NameToLayer("FLOOR");
        //colliderList = new List<Collider>();
        originalMat = this.gameObject.GetComponent<MeshRenderer>().material;
        RedFurniture = RedFurniture != null ? RedFurniture : AssetDatabase.LoadAssetAtPath<Material>("Assets/Choi_Assets/Material/RedFurniture.mat");
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
        // 牢亥配府 家南老 锭
        if(other.GetComponent<XRSocketInteractor>() != null)
        {
            //gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            //print("transform.localScale " + gameObject.transform.localScale);
            return;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("FURNITURE"))
        {
            //colliderList.Add(other);

            colliderCnt++;

            ChangeColor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 牢亥配府 家南老 锭
        if (other.GetComponent<XRSocketInteractor>() != null)
        {
            //gameObject.transform.localScale = Vector3.one;
            //print("transform.localScale " + gameObject.transform.localScale); 
            return;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("FURNITURE"))
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

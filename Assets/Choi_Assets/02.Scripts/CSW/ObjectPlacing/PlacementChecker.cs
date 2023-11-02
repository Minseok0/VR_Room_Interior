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

    public Material originalMat;
    public Material RedFurniture;
    
    private void Start()
    {
        //gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        layerFloor = LayerMask.NameToLayer("FLOOR");
        //colliderList = new List<Collider>();
        originalMat = gameObject.GetComponent<MeshRenderer>().material;
        RedFurniture = RedFurniture != null ? RedFurniture : AssetDatabase.LoadAssetAtPath<Material>("Assets/Choi_Assets/Material/RedFurniture.mat");
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

    private void SetMaterial(Material mat)
    {
        var renderer= GetComponent<MeshRenderer>();
        if(renderer != null)
            renderer.material = mat;
    }
}

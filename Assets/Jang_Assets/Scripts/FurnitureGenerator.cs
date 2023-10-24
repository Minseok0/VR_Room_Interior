using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureGenerator : MonoBehaviour
{
    [SerializeField]
    public GameObject topTarget;
    public GameObject legTarget;
    public List<GameObject> previewTop;
    public List<GameObject> previewLeg;
    // Start is called before the first frame update

    public void SetTop(GameObject target)
    {
        topTarget = target;
    }

    public void SetLeg(GameObject target)
    {
        legTarget = target;
    }

    public void GenerateFurniture(GameObject target)
    {
        //Instantiate(target, gameObject.transform.position + gameObject.transform.forward, Quaternion.identity);
        GameObject cloneObj = new GameObject("newFurniture");
        GameObject topClone = Instantiate(topTarget);
        topClone.transform.parent = cloneObj.transform;

        GameObject legClone = Instantiate(legTarget);
        legClone.transform.parent = cloneObj.transform;
        legClone.transform.localPosition = (legTarget.transform.localPosition - new Vector3(0,0.5f,0));

        cloneObj.transform.position = (gameObject.transform.position + gameObject.transform.forward);
    }

    public void ResetPreviewLeg()
    {
        foreach (GameObject target in previewLeg)
            target.SetActive(false);
    }

    public void ResetPreviewTop()
    {
        foreach (GameObject target in previewTop)
            target.SetActive(false);
    }
}

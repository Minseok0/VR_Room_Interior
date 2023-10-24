using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotScaleTest : MonoBehaviour
{
    public GameObject target;
    public Vector3 pivot;
    public Vector3 newScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScaleAround(target, pivot, newScale);
    }

    public void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
    {
        Vector3 A = target.transform.localPosition;
        Vector3 B = pivot;

        Vector3 C = A - B; // diff from object pivot to desired pivot/origin

        float RS = newScale.y / target.transform.localScale.y; // relative scale factor

        // calc final position post-scale
        Vector3 FP = B + C * RS;

        // finally, actually perform the scale/translation
        target.transform.localScale = newScale;
        target.transform.localPosition = FP;
    }
}

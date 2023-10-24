//using PacketDotNet.Tcp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleScale : MonoBehaviour
{

    public Vector3 Scale;
    public Vector3 pivot;
    public GameObject target;
    [SerializeField] TextMeshProUGUI xtext;
    [SerializeField] TextMeshProUGUI ytext;
    [SerializeField] TextMeshProUGUI ztext;


    public void ScaleX(float x)
    {
        Scale.x = target.transform.localScale.x;
        Scale.x = x;
        target.gameObject.transform.localScale = Scale;
        xtext.text = string.Format("{0:0.#}", target.transform.lossyScale.x * 1000);

    }
    public void ScaleY(float y)
    {
        Scale = target.transform.localScale;
        Scale.y = y;
        ScaleAround(target, pivot, Scale);
        ytext.text = string.Format("{0:0.###}", target.transform.lossyScale.y * 1000);
    }

    public void ScaleZ(float z)
    {
        Scale.z = target.transform.localScale.z;
        Scale.z = z;
        target.gameObject.transform.localScale = Scale;
        ztext.text = string.Format("{0:0.###}", target.transform.lossyScale.z * 1000);
    }

    public void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
    {
        Vector3 A = target.transform.localPosition;
        Vector3 B = pivot;

        Vector3 C = A - B; // diff from object pivot to desired pivot/origin

        float RS = newScale.x / target.transform.localScale.x; // relative scale factor

        // calc final position post-scale
        Vector3 FP = B + C * RS;

        // finally, actually perform the scale/translation
        target.transform.localScale = newScale;
        target.transform.localPosition = FP;
    }

}

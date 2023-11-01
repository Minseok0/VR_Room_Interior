//using PacketDotNet.Tcp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class SimpleScale : MonoBehaviour
{

    public Vector3 Scale;
    public Vector3 pivot;
    public GameObject target;
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;
    [SerializeField] TextMeshProUGUI xtext;
    [SerializeField] TextMeshProUGUI ytext;
    [SerializeField] TextMeshProUGUI ztext;

    public void presetSlider()
    {
        if (target != null)
        {
            sliderX.value = 1000;
            sliderY.value = 1000;
            sliderZ.value = 1000;
            Scale = target.transform.lossyScale;
        }
    }

    public void Settarget(GameObject obj)
    {
        target = obj;
        presetSlider();
    }

    public void ScaleX(float x)
    {
        Scale.x = target.transform.localScale.x;
        Scale.x = sliderX.value;
        target.gameObject.transform.localScale = Scale;
        xtext.text = string.Format("{0:0.#}", target.transform.lossyScale.x * 1000);

    }
    public void ScaleY(float y)
    {
        Scale = target.transform.localScale;
        Scale.y = sliderY.value;
        ScaleAround(target, pivot, Scale);
        ytext.text = string.Format("{0:0.###}", target.transform.lossyScale.y * 1000);
    }

    public void ScaleZ(float z)
    {
        Scale.z = target.transform.localScale.z;
        Scale.z = sliderZ.value;
        target.gameObject.transform.localScale = Scale;
        ztext.text = string.Format("{0:0.###}", target.transform.lossyScale.z * 1000);
    }

    public void ScaleChange()
    {
        target.transform.localScale = new Vector3(sliderX.value / 1000, target.transform.localScale.y, sliderZ.value / 1000);
        Scale = new Vector3(sliderX.value/1000, sliderY.value/1000, sliderZ.value/1000);
        ScaleAround(target, pivot, Scale);
        xtext.text = ((int)(target.transform.lossyScale.x * 1000)).ToString();
        ytext.text = ((int)(target.transform.lossyScale.y * 1000)).ToString();
        ztext.text = ((int)(target.transform.lossyScale.z * 1000)).ToString();
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

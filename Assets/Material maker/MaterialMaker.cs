using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static Unity.Burst.Intrinsics.X86.Avx;

public class MaterialMaker : MonoBehaviour
{
    public Material material;
    public GameObject matBall;
    public RawImage previewImage;

    public Slider sliderR;
    public Slider sliderG;
    public Slider sliderB;

    public Color matColor;


    private void Start()
    {
        material = matBall.GetComponent<MeshRenderer>().material;
        material.SetColor("_Color",Color.white);
        matColor = material.color;
        sliderR.value = matColor.r;
        sliderG.value = matColor.g;
        sliderB.value = matColor.b;
    }
    private void Update()
    {
        if (material.GetColor("_Color").r != sliderR.value / 255)
            ChangeColorR(sliderR);
        if (material.GetColor("_Color").g != sliderG.value / 255)
            ChangeColorR(sliderG);
        if (material.GetColor("_Color").b != sliderB.value / 255)
            ChangeColorR(sliderB);
    }
    // Start is called before the first frame update
    public void GenerateMatball()
    {
        Instantiate(matBall, gameObject.transform.position + gameObject.transform.forward, Quaternion.identity);
    }

    public void CopyMaterial(Material mat)
    {
        matColor = material.color;
        material.CopyPropertiesFromMaterial(mat);
        material.color = matColor;
        previewImage.material.CopyPropertiesFromMaterial(material);
    }

    public void IncreaseValue(Slider Slider)
    {
        if(Slider.value < 255)
            Slider.value+=1;
    }

    public void decreaseValue(Slider Slider)
    {
        if (Slider.value > 0)
            Slider.value-=1;
    }

    public void ChangeColorR(Slider Slider)
    {
        TextMeshProUGUI tmp = Slider.GetComponentInChildren<TextMeshProUGUI>();
        matColor.r = Slider.value/255;
        material.SetColor("_Color",matColor);
        tmp.SetText(Slider.value.ToString());
        previewImage.material.color = matColor;
    }
    public void ChangeColorG(Slider Slider)
    {
        TextMeshProUGUI tmp = Slider.GetComponentInChildren<TextMeshProUGUI>();
        matColor.g = Slider.value/255;
        material.SetColor("_Color", matColor);
        tmp.SetText(Slider.value.ToString());
        previewImage.material.color = matColor;
    }
    public void ChangeColorB(Slider Slider)
    {
        TextMeshProUGUI tmp = Slider.GetComponentInChildren<TextMeshProUGUI>();
        matColor.b = Slider.value / 255;
        material.SetColor("_Color", matColor);
        tmp.SetText(Slider.value.ToString());
        previewImage.material.color = matColor;
    }
}

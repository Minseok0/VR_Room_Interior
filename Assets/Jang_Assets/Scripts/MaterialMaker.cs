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
        sliderR.value = material.color.r;
        sliderG.value = material.color.g;
        sliderB.value = material.color.b;
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
        if (Slider.value <= 254)
            Slider.value += 1;
        else
            Slider.value = 255;
        ColorChange();
    }

    public void decreaseValue(Slider Slider)
    {
        if (Slider.value > 0)
            Slider.value -= 1;
        else
            Slider.value = 0;
        ColorChange();
    }

    public void ColorChange()
    {
        material.color = new Color(sliderR.value/255, sliderG.value/255, sliderB.value / 255);
        previewImage.material.color = material.color; 
        sliderR.GetComponentInChildren<TextMeshProUGUI>().SetText(sliderR.value.ToString());
        sliderG.GetComponentInChildren<TextMeshProUGUI>().SetText(sliderG.value.ToString());
        sliderB.GetComponentInChildren<TextMeshProUGUI>().SetText(sliderB.value.ToString());
    }

    public void PresetColorChange(Image img)
    {
        material.color = img.color;
        previewImage.material.color = material.color;
        sliderR.value = (int)(img.color.r * 255);
        sliderG.value = (int)(img.color.g * 255);
        sliderB.value = (int)(img.color.b * 255);
        sliderR.GetComponentInChildren<TextMeshProUGUI>().SetText(sliderR.value.ToString());
        sliderG.GetComponentInChildren<TextMeshProUGUI>().SetText(sliderG.value.ToString());
        sliderB.GetComponentInChildren<TextMeshProUGUI>().SetText(sliderB.value.ToString());
    }
}

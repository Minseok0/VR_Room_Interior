using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorMix : MonoBehaviour
{
    public Color color;

    public Slider sr;
    public Slider sg;
    public Slider sb;

    public TextMeshProUGUI R;
    public TextMeshProUGUI G;
    public TextMeshProUGUI B;

    public Material mat;

    private void Awake()
    {
        color = mat.color;
        R.text = ((int)(color.r * 100)).ToString();
        G.text = ((int)(color.g * 100)).ToString();
        B.text = ((int)(color.b * 100)).ToString();
    }

    public void ChangeRed(float v)
    {
        color.r = sr.value;
        R.text = sr.value.ToString();
        mat.color = color;
    }
    public void ChangeGreen(float v)
    {
        color.g = sg.value;
        G.text = sb.value.ToString();
        mat.color = color;
    }
    public void ChangeBlue(float v)
    {
        color.b = sb.value;
        B.text = sb.value.ToString();
        mat.color = color;
    }

}

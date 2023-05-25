using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ColorMix : MonoBehaviour
{
    public float red = 0;
    public float green = 0;
    public float blue = 0;

    public Color color = Color.white;

    public Slider sr;
    public Slider sg;
    public Slider sb;

    public string R;
    public string G;
    public string B;

    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        color.r = sr.value;
        color.g = sg.value;
        color.b = sb.value;
        mat.color = color;
    }

}

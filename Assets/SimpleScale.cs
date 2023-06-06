using PacketDotNet.Tcp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleScale : MonoBehaviour
{

    public Vector3 Scale;
    public GameObject target;
    [SerializeField] TextMeshProUGUI xtext;
    [SerializeField] TextMeshProUGUI ytext;
    [SerializeField] TextMeshProUGUI ztext;
    public void ScaleX(float x)
    {

        Scale.x = x;
        target.transform.localScale.Set(Scale.x, Scale.y, Scale.z);
        xtext.text = "" + target.transform.lossyScale.x;

    }
    public void ScaleY(float y)
    {
        Scale.y = y;
        target.transform.localScale.Set(Scale.x, Scale.y, Scale.z);
        xtext.text = "" + target.transform.lossyScale.y;
    }

    public void ScaleZ(float z)
    {
        Scale.x = z;
        target.transform.localScale.Set(Scale.x, Scale.y, Scale.z);
        xtext.text = "" + target.transform.lossyScale.z;
    }

}

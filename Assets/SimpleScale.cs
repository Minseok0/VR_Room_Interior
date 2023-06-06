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
        target.gameObject.transform.localScale = Scale;
        xtext.text = "" + target.transform.lossyScale.x;

    }
    public void ScaleY(float y)
    {
        Scale.y = y;
        target.gameObject.transform.localScale = Scale;
        ytext.text = "" + target.transform.lossyScale.y;
    }

    public void ScaleZ(float z)
    {
        Scale.z = z;
        target.gameObject.transform.localScale = Scale;
        ztext.text = "" + target.transform.lossyScale.z;
    }

}

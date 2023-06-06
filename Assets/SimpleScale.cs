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
        Scale.x = target.transform.localScale.x;
        Scale.x = x;
        target.gameObject.transform.localScale = Scale;
        xtext.text = string.Format("{0:0.#}", target.transform.lossyScale.x * 1000);

    }
    public void ScaleY(float y)
    {
        Scale.y = target.transform.localScale.y;
        Scale.y = y;
        target.gameObject.transform.localScale = Scale;
        ytext.text = string.Format("{0:0.###}", target.transform.lossyScale.y * 1000);
    }

    public void ScaleZ(float z)
    {
        Scale.z = target.transform.localScale.z;
        Scale.z = z;
        target.gameObject.transform.localScale = Scale;
        ztext.text = string.Format("{0:0.###}", target.transform.lossyScale.z * 1000);
    }

}

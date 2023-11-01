using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshUIControl : MonoBehaviour
{
    public GameObject target;
    [SerializeField] SimpleScale simpleScale;
    [SerializeField] GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        target = null;
    }

    public void TargetOn(GameObject item)
    {
        target = item;
        simpleScale.Settarget(item);
    }

    public void UIOnOff()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
            target = null;
        }
        if (!ReferenceEquals(target, null))
        {
            panel.SetActive(true);
        }
        
    }

}

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
        simpleScale.target = target;
        simpleScale.Scale = target.transform.localScale;
    }

    public void UIActivate()
    {
        if(!ReferenceEquals(target, null))
        {
            panel.SetActive(true);
        }
    }

    public void UIDeActivate()
    {
        panel.SetActive(false);
        target = null;
    }
}

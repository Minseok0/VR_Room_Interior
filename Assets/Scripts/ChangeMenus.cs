using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMenus : MonoBehaviour
{
    [SerializeField] GameObject[] menus;

    private int idx = 0;
    
    void OnEnable()
    {
        menus[idx].SetActive(true);
    }

    private void OnDisable()
    {
        menus[idx].SetActive(false);
    }

    public void ChangeToLeftMenu()
    {
        menus[idx].SetActive(false);
        if(idx == 0)
            idx = menus.Length - 1;
        else
            idx--;
        menus[idx].SetActive(true);
    }

    public void ChangeToRightMenu()
    {
        menus[idx].SetActive(false);
        if (idx == menus.Length - 1)
            idx = 0;
        else
            idx++;
        menus[idx].SetActive(true);
    }
}

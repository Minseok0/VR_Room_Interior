using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject optionMenu;

    private void Start()
    {
        print(optionMenu.name);
        //if (optionMenu == null)
        //{
        //    Debug.LogWarning("optionMenu == null");
        //    GameObject.Find("OptionMenu");
        //}
        optionMenu = GameObject.Find("OptionMenu");
    }

    public void ToggleOptionMenu()
    {
        if (optionMenu == null)
        {
            optionMenu = GameObject.Find("OptionMenu");
            print("Find");
        }
        optionMenu.SetActive(!optionMenu.activeSelf);
    }
}
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
        if (optionMenu == null)
        {
            Debug.LogWarning("optionMenu == null");
            GameObject.Find("OptionMenu");
        }
    }

    public void ToggleOptionMenu()
    {
        optionMenu.SetActive(!optionMenu.activeSelf);
    }




}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    private Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        tr.position = Camera.main.transform.position + Camera.main.transform.forward*0.5f + Camera.main.transform.up * (-0.2f);
    }

    public void ButtonPressed_Close()
    {
        gameObject.SetActive(false);
    }

    public void ButtonPressed_KeyCheck()
    {
        Debug.Log("OnKeyCheckButtonPressed");
    }

    public void ButtonPressed_HeightSetting()
    {
        Debug.Log("HeightSettingButtonPressed");


    }

    public void ButtonPressed_ProgramExit()
    {
        Managers.Game.GameExit();
    }
}

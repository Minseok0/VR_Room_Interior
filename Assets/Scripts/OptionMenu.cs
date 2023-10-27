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
        tr.position = transform.parent.position + tr.parent.forward*0.5f;
    }

    public void ButtonPressed_Close()
    {
        gameObject.SetActive(false);
    }

    public void ButtonPressed_KeyCheck()
    {
        Debug.Log("OnKeyCheckButtonPressed");
    }

    public void ButtonPressed_SoundSetting()
    {
        Debug.Log("SoundSettingButtonPressed");

    }

    public void ButtonPressed_ProgramExit()
    {
        Managers.Game.GameExit();
    }
}

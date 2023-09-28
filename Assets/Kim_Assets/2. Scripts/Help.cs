using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    public GameObject helpPanel; // ���� â�� ������ GameObject (Inspector���� ����)
    public GameObject OKButton;

    void Start()
    {
        // ���� �г� ��Ȱ��ȭ
        helpPanel.SetActive(false);
        OKButton.SetActive(false);
    }

    public void ShowHelp()
    {
        // "Help" ��ư�� Ŭ���� �� ȣ��� �Լ�
        helpPanel.SetActive(true);
        OKButton.SetActive(true);
    }

    public void CloseHelp()
    {
        // ���� â�� ���� �� ȣ��� �Լ�
        helpPanel.SetActive(false);
        OKButton.SetActive(false);
    }
}
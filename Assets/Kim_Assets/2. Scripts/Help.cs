using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    public GameObject helpPanel; // 도움말 창을 연결할 GameObject (Inspector에서 설정)
    public GameObject OKButton;

    void Start()
    {
        // 도움말 패널 비활성화
        helpPanel.SetActive(false);
        OKButton.SetActive(false);
    }

    public void ShowHelp()
    {
        // "Help" 버튼을 클릭할 때 호출될 함수
        helpPanel.SetActive(true);
        OKButton.SetActive(true);
    }

    public void CloseHelp()
    {
        // 도움말 창을 닫을 때 호출될 함수
        helpPanel.SetActive(false);
        OKButton.SetActive(false);
    }
}
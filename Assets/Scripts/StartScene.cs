using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("1_MainPlay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

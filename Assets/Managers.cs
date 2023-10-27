using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers _instance;
    public static Managers Instance { get { Init(); return _instance; } }

    UIManager ui = new UIManager();
    SoundManager sound = new SoundManager();
    GameManager game = new GameManager();

    public static UIManager UI { get { return Instance.ui; } }
    public static SoundManager Sound { get { return Instance.sound; } }
    public static GameManager Game { get { return Instance.game; } }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);

            _instance = go.GetComponent<Managers>();
        }
    }
}

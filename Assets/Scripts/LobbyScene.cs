using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : MonoBehaviour
{
    [SerializeField] private AudioClip bgmClip;
    void Start()
    {
        Managers.Sound.BgmPlay(bgmClip);
    }

}

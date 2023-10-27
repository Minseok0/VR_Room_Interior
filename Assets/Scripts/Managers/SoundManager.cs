using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    public AudioSource bgmAudio;
    public AudioSource sfxAudio;

    private void Awake()
    {
        audioSources = this.gameObject.GetComponents<AudioSource>();
        bgmAudio = audioSources[0];
        sfxAudio = audioSources[1];
    }

    void Start()
    {
        bgmAudio.loop = true;
        BgmPlay(bgmAudio.clip);
    }

    public void BgmPlay(AudioClip audioClip, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;

        if (bgmAudio.isPlaying)
            bgmAudio.Stop();

        bgmAudio.pitch = pitch;
        bgmAudio.clip = audioClip;
        bgmAudio.Play();
    }

    public void SfxPlay(AudioClip audioClip, float pitch = 1.0f)
    {
        sfxAudio.pitch = pitch;
        sfxAudio.PlayOneShot(audioClip);
    }

    public void SetBgmVolume(float value)
    {
        bgmAudio.volume = value;
    }
}

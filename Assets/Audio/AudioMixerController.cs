using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer myAudioListen;

    public void MasterVolume(float volume)
    {
        myAudioListen.SetFloat("MasterVolume", Mathf.Log10(volume)*20);
    }

    public void EffectVolume(float volume)
    {
        myAudioListen.SetFloat("EffectVolume", Mathf.Log10(volume)*20);
    }

    public void MusicVolume(float volume)
    {
        myAudioListen.SetFloat("MusicVolume", Mathf.Log10(volume)*20);
    }
}

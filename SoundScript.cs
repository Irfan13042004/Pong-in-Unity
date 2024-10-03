using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//LEARN ABOUT AUDIOMIXER AND ITS FUNCTIONALITIES 
// This Script handles the audio system of the Game.

public class SoundScript : MonoBehaviour
{

    public AudioMixer _audioMixer;
    public void SetVolume(float vol)
    {
        _audioMixer.SetFloat("Music",vol);
    }

    public void SetSFX(float vol2)
    {
        _audioMixer.SetFloat("SFX",vol2);
    }

    public void SetMaster(float master)
    {
        _audioMixer.SetFloat("Volume",master);
    }
}

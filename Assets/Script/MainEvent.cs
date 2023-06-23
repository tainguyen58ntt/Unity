using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainEvent : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;

    private void Start()
    {
        mixer.GetFloat("volume", out value);
        volumeSlider.value = value;
    }

    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
    }
}

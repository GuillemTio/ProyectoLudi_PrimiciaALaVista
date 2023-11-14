using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider m_VolumeSlider;
    void Start()
    {
        if (PlayerPrefs.HasKey("AudioMixer"))
        {
            PlayerPrefs.SetFloat("AudioMixer", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = m_VolumeSlider.value;
        Save();
    }

    void Load()
    {
        m_VolumeSlider.value = PlayerPrefs.GetFloat("AudioMixer");
    }

    void Save()
    {
        PlayerPrefs.SetFloat("AudioMixer", m_VolumeSlider.value);
    }
}

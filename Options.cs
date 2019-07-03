using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.PostProcessing;

public class Options : MonoBehaviour
{
    // Include the namespace

    // Assign the profile that you want to swap into
    public PostProcessingProfile Low;
    public PostProcessingProfile Medium;
    public PostProcessingProfile High;


    public AudioMixer MasterMixer;

    public void SetMasterVolume(float volume)
    {
        MasterMixer.SetFloat("Volume", volume);

        if (volume == -30)
        {
            MasterMixer.SetFloat("Volume", -80);
        }
    }

    public void SetMusicVolume(float volume)
    {
        MasterMixer.SetFloat("Music", volume);
        if (volume == -30)
        {
            MasterMixer.SetFloat("Music", -80);
        }
    }

    public void SetEffectsVolume(float volume)
    {
        MasterMixer.SetFloat("Effects", volume);

        if (volume == -30)
        {
            MasterMixer.SetFloat("Effects", -80);
        }
    }

    public void SetWeatherVolume(float volume)
    {
        MasterMixer.SetFloat("Weather", volume);
        if (volume == -30)
        {
            MasterMixer.SetFloat("Weather", -80);
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }


}

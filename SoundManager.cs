using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public Sounds[] sounds;
    public AudioMixerGroup audioMixer;

    public Options optionsObj;

    void Awake ()
    {
		foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup = audioMixer;


            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
	}
	
	public void Play (string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
	}

    public void CashSound()
    {
        Play("Cash");
    }

    public void Click1Sound()
    {
        Play("Click 1");
    }

    public void Click2Sound()
    {
        Play("Click 2");
    }

    public void Click3Sound()
    {
        Play("Click 3");
    }

    public void BellSound()
    {
        Play("Bell");
    }

    public void WrongSound()
    {
        Play("Wrong");
    }
}

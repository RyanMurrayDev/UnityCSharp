﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;


    public static AudioManager instance;

    void Awake()
    {
        //singleton 
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
           s.source= gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
        }
    }

    public void SetVolume(float f)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = f;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + "not found");
        }
        else
        {
            Debug.Log("playing " + name);
            s.source.Play();
        }
    }

    public void StopPlay(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + "not found");
        }
        else
        {
            s.source.Stop();
        }
    }

}

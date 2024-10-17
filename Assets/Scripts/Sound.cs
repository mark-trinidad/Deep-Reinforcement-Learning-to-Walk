using UnityEngine.Audio;
using UnityEngine;
using System;


[System.Serializable]
public class Sound 
{

    public string name;
    public AudioClip clip;
    public AudioMixerGroup mixerGroup;

    [Range(0f,1f)]

    public float volume;

    [Range(.1f,3)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}

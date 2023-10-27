using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class SoundScript
{
    public string Name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;


}

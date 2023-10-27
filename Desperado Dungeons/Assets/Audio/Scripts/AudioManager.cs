using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManager : MonoBehaviour
{
    public SoundScript[] sound;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(SoundScript currentSound in sound)
        {
            currentSound.source = gameObject.AddComponent<AudioSource>();
            currentSound.source.clip = currentSound.clip;
            currentSound.source.volume = currentSound.volume;
            currentSound.source.pitch = currentSound.pitch;
            currentSound.source.loop = currentSound.loop;
        }
    }

    void Start()
    {
        PlaySound("LevelTheme");
    }

    public void PlaySound(string soundUsed)
    {
        SoundScript s = Array.Find(sound, sound => sound.Name == soundUsed);
        s.source.Play();

    }
}

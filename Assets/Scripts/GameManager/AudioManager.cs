using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public int specifixBackgroundSfx;

    private void Awake()
    {
        foreach(Sound s in  sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.volume = s.volume;
            s.audioSource.clip = s.clip;
        }
    }

    private void Start()
    {
        sounds[Random.Range(0, sounds.Length)].audioSource.Play();
    }
}


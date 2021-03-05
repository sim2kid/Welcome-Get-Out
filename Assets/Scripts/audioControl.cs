using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioControl : MonoBehaviour
{
    private AudioSource src;
    private bool m_Playing;
    private void OnEnable()
    {
        src = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (m_Playing)
            if (!src.isPlaying)
                m_Playing = false;
    }

    public void PlaySound(AudioClip audio)
    {
        m_Playing = true;
        src.PlayOneShot(audio);
    }

    public void InterruptAudio(AudioClip audio) 
    {
        StopAudio();
        PlaySound(audio);
    }

    public void StopAudio() 
    {
        src.Stop();
    }

    public bool IsPlaying() 
    {
        return m_Playing;
    }
}
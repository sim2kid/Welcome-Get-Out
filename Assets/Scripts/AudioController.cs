using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private AudioSource src;
    private bool m_Playing;

    public AudioClip sfxClip;

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
        if (audio == null) {
            PlaySound();
            return;
        }
        m_Playing = true;
        src.PlayOneShot(audio);
    }

    public void PlaySound()
    {
        if (sfxClip != null)
            PlaySound(sfxClip);
    }

    public void InterruptAudio(AudioClip audio) 
    {
        if (audio == null)
        {
            InterruptAudio();
            return;
        }
        StopAudio();
        PlaySound(audio);
    }

    public void InterruptAudio()
    {
        if (sfxClip != null)
            InterruptAudio(sfxClip);
    }

    public void ChangeDefaultSFX(AudioClip audio) 
    {
        sfxClip = audio;
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
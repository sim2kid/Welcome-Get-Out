using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioControl : MonoBehaviour
{
    private AudioSource src;
    void Start()
    {
        src = GetComponent<AudioSource>();
    }
    
    //will only play once per update max
    public void PlaySound(AudioClip audio)
    {
        src.PlayOneShot(audio);
    }
}
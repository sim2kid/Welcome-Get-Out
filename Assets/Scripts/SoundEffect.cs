using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : Intractable
{
    [SerializeField]
    private AudioClip soundToMake;
    private AudioControl audioController;

    private void Start()
    {
        audioController = GameObject.Find("Audio").GetComponent<AudioControl>();
        if (audioController == null) 
        {
            
        }
    }

    public override void OnUnclick()
    {
        if(soundToMake != null)
            audioController.PlaySound(soundToMake);
        base.OnUnclick();
    }
}

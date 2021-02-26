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
        try
        {
            audioController = GameObject.Find("Audio").GetComponent<AudioControl>();
        } catch {
            Debug.Log("No Audio Controller. Making One...");
            audioController = new GameObject().AddComponent<AudioControl>();
            audioController.gameObject.name = "Audio";
        }
    }

    public override void OnUnclick()
    {
        if(soundToMake != null)
            audioController.PlaySound(soundToMake);
        base.OnUnclick();
    }
}

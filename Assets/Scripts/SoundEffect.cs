using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : Intractable
{
    [SerializeField]
    private AudioClip soundToMake;
    private AudioController audioController;

    private void Start()
    {
        try
        {
            audioController = GameObject.Find("SoundEffectController").GetComponent<AudioController>();
        } catch {
            Debug.Log("No Audio Controller. Making One...");
            audioController = new GameObject().AddComponent<AudioController>();
            audioController.gameObject.name = "SoundEffectController";
        }
    }

    public override void OnUnclick()
    {
        if(soundToMake != null)
            audioController.PlaySound(soundToMake);
        base.OnUnclick();
    }
}

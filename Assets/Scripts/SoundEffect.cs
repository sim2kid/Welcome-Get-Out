using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : Intractable
{
    [SerializeField]
    private AudioClip soundToMake;

    public override void OnUnclick()
    {
        // Put in the call to the sound files here
        base.OnUnclick();
    }
}

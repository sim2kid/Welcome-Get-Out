using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : CycleSprite
{
    [SerializeField]
    private AudioClip soundToMake;

    protected override void OnCycle()
    {
        // Put in the call to the sound files here
        base.OnCycle();
    }
}

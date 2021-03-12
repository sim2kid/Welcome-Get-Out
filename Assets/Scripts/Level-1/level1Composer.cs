using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1Composer : MonoBehaviour
{
    [SerializeField]
    private DialogueTree curtainDialogue;
    [SerializeField]
    private NarratorController narrator;
    [SerializeField]
    private AudioController soundEffects;
    [SerializeField]
    private Animator CurtainAnimator;

    private int touchCount;

    private void Start()
    {
        touchCount = 0;
    }

    public void OpenCurtains() 
    {
        CurtainAnimator.SetTrigger("Open");
    }
    public void TouchCurtainDialogue() 
    {
        if (touchCount <= 0) 
        {
            narrator.NewNarration(curtainDialogue, 0);
        }
        else 
        {
            narrator.Trigger();
        }
        touchCount++;
    }
}

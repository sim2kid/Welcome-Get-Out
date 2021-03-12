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
    [SerializeField]
    private DialogueTree openSesameDialogue;
    [SerializeField]
    private DialogueTree menu;
    [SerializeField]
    private DialogueTree rat;
    [SerializeField]
    private Animator ratamation;
    [SerializeField]
    private GameObject exitButton;
    [SerializeField]
    private GameObject exitAlt;

    private int touchCount;
    public int treeCount;

    private void Start()
    {
        touchCount = 0;
        treeCount = 0;
    }

    private void Update()
    {
        if (narrator.IsOver()) 
        {
            switch (treeCount) 
            {
                case 1:
                    treeCount++;
                    CurtainAnimator.SetTrigger("Open");
                    narrator.NewNarration(menu, 0);
                    break;
                case 2:
                    treeCount++;
                    narrator.NewNarration(rat, 0);
                    ratamation.SetTrigger("RunRatRun");
                    break;
                case 3:
                    treeCount++;
                    exitButton.transform.position = new Vector3(0, exitButton.transform.position.y, exitButton.transform.position.z);
                    exitAlt.transform.position = new Vector3(50, exitAlt.transform.position.y, exitAlt.transform.position.z);
                    break;
            }
                
        }
    }

    public void OpenCurtains() 
    {
        CurtainAnimator.SetTrigger("Open");
        narrator.NewNarration(openSesameDialogue, 0);
        treeCount++;
    }
    public void TouchCurtainDialogue() 
    {
        if (touchCount == 0) 
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

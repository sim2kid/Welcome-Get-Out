﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2Composer : MonoBehaviour
{
    public int stage;

    [SerializeField]
    private Animator glass;
    [SerializeField]
    private GameObject rock;
    [SerializeField]
    private GameObject paper;
    [SerializeField]
    private GameObject scissors;

    [SerializeField]
    private NarratorController narrator;

    [SerializeField]
    private DialogueTree dt_rock;
    [SerializeField]
    private DialogueTree dt_scissors;
    [SerializeField]
    private DialogueTree dt_ribbon;
    [SerializeField]
    private DialogueTree dt_button;

    [SerializeField]
    private Animator chest;


    [SerializeField]
    private RockPaperScissors rps;

    bool pickedUpScissors, chestClosed;

    void Start()
    {
        stage = 0;
        pickedUpScissors = false;
        chestClosed = true;
    }

    public void RockOnGlass() 
    {
        if (stage < 3)
        {
            if(stage == 0)
                narrator.NewNarration(dt_rock, 0);
            glass.SetTrigger("Hit");
            stage++;
        }
        if (stage == 3)
        {
            narrator.Trigger();
            rock.GetComponent<DragConstraints>().x = false;
            rock.GetComponent<DragConstraints>().y = false;
            scissors.GetComponent<DragConstraints>().x = false;
            scissors.GetComponent<DragConstraints>().y = false;
            paper.GetComponent<DragConstraints>().x = false;
            paper.GetComponent<DragConstraints>().y = false;
        }
    }

    public void openChest() 
    {
        if (chestClosed)
        {
            narrator.NewNarration(dt_ribbon, 0);
            chestClosed = false;
            chest.SetTrigger("Open");
        }
        
    }

    public void UnlockOnDrag(int type) {
        GameObject obj = rock;
        switch (type)
        {
            case 0:
                obj = rock;
                break;
            case 1:
                obj = paper;
                break;
            case 2:
                obj = scissors;
                if (!pickedUpScissors)
                    narrator.NewNarration(dt_scissors, 0);
                pickedUpScissors = true;
                break;
        }
        obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, 20);
        obj.transform.parent = gameObject.transform;
    }

    public void playerRoll(int type) 
    {
        rps.playerRoll(type);
    }

    public void turnOffCheats() 
    {
        rps.canCheat = false;
    }

    public void onWin() 
    {
        //Goto Next Scene
        narrator.NewNarration(dt_button, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RockPaperScissors : MonoBehaviour
{
    [SerializeField]
    private RollController player;
    [SerializeField]
    private RollController narrator;

    [SerializeField]
    private UnityEvent Loose;
    [SerializeField]
    private UnityEvent Win;

    [SerializeField]
    private AudioClip rollingSFX;
    [SerializeField]
    private AudioController audioController;

    public bool canCheat;
    private bool listenForRoll;

    void Start()
    {
        canCheat = true;
        listenForRoll = false;
        playerRoll(1);
    }

    private void Update()
    {
        if (listenForRoll) 
        {
            if (player.rollState != RollState.None && narrator.rollState != RollState.None) 
            {
                listenForRoll = false;
                onRoll();
            }
        }
    }

    public void playerRoll(int what) 
    {
        if (!player.midRoll)
        {
            audioController.PlaySound(rollingSFX);
            player.Roll(what);
            if (canCheat)
            {
                narrator.Roll(whatBeatsThis(what));
            }
            else
            {
                narrator.Roll(whatLossesThis(what));
            }
            listenForRoll = true;
        }
    }

    protected void onRoll() 
    {
        switch (whoWins((int)player.rollState, (int)narrator.rollState)) 
        {
            case 0:
                //we win
                //Debug.Log("Win");
                Win.Invoke();
                break;
            case 1:
                //Narrator Wins
                //Debug.Log("Loose");
                Loose.Invoke();
                break;
            case -1:
                //Tie!
                //Debug.Log("Tie");
                break;
        }
    }

    private int whoWins(int a, int b) 
    {
        if (a == b)
            return -1;
        if (whatBeatsThis(a) == b)
            return 1;
        return 0;
    }

    private int whatBeatsThis(int one) 
    {
        switch (one) 
        {
            case 0:
                return 1;
            case 1:
                return 2;
            case 2:
                return 0;
            default:
                return -1;
        }
    }

    private int whatLossesThis(int one)
    {
        switch (one)
        {
            case 0:
                return 2;
            case 1:
                return 0;
            case 2:
                return 1;
            default:
                return -1;
        }
    }
}

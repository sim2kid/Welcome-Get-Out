using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPaperScissors : MonoBehaviour
{
    [SerializeField]
    private RollController player;
    [SerializeField]
    private RollController narrator;

    public bool canCheat;
    private bool listenForRoll;

    void Start()
    {
        player.Roll(0);
        narrator.Roll(0);
        canCheat = true;
        listenForRoll = false;
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
        player.Roll(what);
        if (canCheat)
            narrator.Roll(whatBeatsThis(what));
        else
            narrator.RollRandom();
        listenForRoll = true;
    }

    protected void onRoll() 
    {
        switch (whoWins((int)player.rollState, (int)narrator.rollState)) 
        {
            case 0:
                //we win
                Debug.Log("Win");
                break;
            case 1:
                //Narrator Wins
                Debug.Log("Loose");
                break;
            case -1:
                //Tie!
                Debug.Log("Tie");
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
}

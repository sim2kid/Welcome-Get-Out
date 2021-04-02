using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4Composer : MonoBehaviour
{
    bool lockette, key, win = false;
    [SerializeField]
    NarratorController narrator;

    private void Update()
    {
        if (win && narrator.IsOver()) 
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level-5");
        }
    }

    public void LockClicked()
    {
        if (!lockette && !win) 
        {
            lockette = true;
            narrator.JumpToLine(7);
        }
    }

    public void KeyClicked()
    {
        if (!key && !win)
        {
            key = true;
            narrator.JumpToLine(12);
        }
    }

    public void Win()
    {
        //Key disapears
        //Lock unlocks
        //Clock is in the box
        //box becomes opened
        win = true;
        narrator.JumpToLine(18);
    }
}

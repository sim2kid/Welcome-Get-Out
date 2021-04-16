using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4Composer : MonoBehaviour
{
    bool lockette, key, win = false;
    [SerializeField]
    NarratorController narrator;
    [SerializeField]
    GameObject theBox, theUnlockedBox;

    private void Start()
    {
        theBox.SetActive(true);
        theUnlockedBox.SetActive(false);
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

    public void Clock() 
    { 
        if(win)
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level-5");
    }

    public void Win()
    {
        theBox.SetActive(false);
        theUnlockedBox.SetActive(true);
        win = true;
        narrator.JumpToLine(18);
    }
}

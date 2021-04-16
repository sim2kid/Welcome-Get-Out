using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level5Composer : MonoBehaviour
{
    [SerializeField]
    ClockController clock;
    [SerializeField]
    NarratorController narrator;
    [SerializeField]
    private int Epoch;

    // Start is called before the first frame update
    void Start()
    {
        Epoch = 0;
    }

    private void Update()
    {
        if (Epoch == 3 && !narrator.IsTalking() && narrator.atIndex() == 22)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level-6");
        }
    }

    public void OnClick() 
    {
        if (Epoch == 0)
        {
            Epoch++;
            narrator.JumpToLine(5);
        }
    }
    public void OnSet()
    {
        if (Epoch == 1 && !narrator.IsTalking() && !isCorrect())
        {
            Epoch++;
            narrator.JumpToLine(6);
        }
        if (isCorrect() && Epoch != 3) 
        {
            Epoch = 3;
            narrator.JumpToLine(19);
        }
    }
    private bool isCorrect() 
    {
        return clock.hTime == System.DateTime.Now.Hour && clock.mTime == System.DateTime.Now.Minute;
    }
}

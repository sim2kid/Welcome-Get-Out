using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level7Composer : MonoBehaviour
{
    [SerializeField]
    NarratorController narrator;
    [SerializeField]
    CodeChecker check;

    [SerializeField]
    Persistent data;

    private int epoch;
    private bool hovered;

    void Start()
    {
        data.UpdateScene();
        epoch = 0;
        hovered = false;
    }

    public void onHover() 
    {
        if (!hovered) 
        {
            narrator.JumpToLine(3);
            hovered = true;
        }
    }

    private void Update()
    {
        if (check.codeFixedAmount() == 1 && epoch == 0) 
        {
            epoch++;
            narrator.JumpToLine(8);
        }
        if (check.codeFixedAmount() == 2 && epoch == 1)
        {
            epoch++;
            narrator.JumpToLine(12);
            check.RelocateCode();
        }
        if (check.codeFixedAmount() == 3 && epoch == 2)
        {
            epoch++;
            narrator.JumpToLine(16);
            data.NarratorIsNice = true;
        }
        if (epoch == 3 && narrator.IsOver() && !narrator.IsTalking()) 
        {
            Win();
        }
    }

    private void Win() 
    {
        SceneManager.LoadScene("Credits");
    }

}

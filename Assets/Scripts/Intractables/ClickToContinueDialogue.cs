using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToContinueDialogue : Intractable
{
    private NarratorController narrator;
    private void Start()
    {
        try
        {
            narrator = GameObject.Find("NarratorController").GetComponent<NarratorController>();
        }
        catch
        {
            Debug.Log("No Audio Controller. Making One...");
            narrator = new GameObject().AddComponent<NarratorController>();
            narrator.gameObject.name = "NarratorController";
        }
    }

    public override void OnFullClick()
    {
        narrator.Trigger();
        base.OnFullClick();
    }
}

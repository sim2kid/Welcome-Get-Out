using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level3Composser : MonoBehaviour
{
    [SerializeField] 
    private int epoch;
    [SerializeField]
    private ProgressBar progressBar;
    [SerializeField]
    NarratorController narrator;

    private UnityEvent epochTrigger;

    void Start()
    {
        epoch = 0;
        progressBar.modifyProgress(-1);
        epochTrigger = new UnityEvent();
        epochTrigger.AddListener(TriggerEpoch);
    }

    public void TriggerEpoch() 
    {
        epoch++;
    }

    public void ButtonPress() 
    {
        switch (epoch)
        {
            case 0:
                progressBar.modifyProgress(0.02f);
                narrator.Trigger(epochTrigger);
                break;
            case 1:
                progressBar.modifyProgress(0.02f);
                narrator.Trigger(epochTrigger);
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (epoch)
        {
            case 0:
                if (progressBar.GetProgress() > 0.90)
                {
                    progressBar.modifyProgress(-0.5f * Time.fixedDeltaTime);
                }
                if (progressBar.GetProgress() > 0.15) 
                {
                    progressBar.modifyProgress(-0.2f * Time.fixedDeltaTime);
                }
                if (progressBar.GetProgress() > 0.09)
                {
                    progressBar.modifyProgress(-0.2f * Time.fixedDeltaTime);
                }

                progressBar.modifyProgress(-0.05f * Time.fixedDeltaTime);
                break;
            case 1:
                if (progressBar.GetProgress() > 0.90)
                {
                    progressBar.modifyProgress(-0.5f * Time.fixedDeltaTime);
                }
                if (progressBar.GetProgress() > 0.15)
                {
                    progressBar.modifyProgress(-0.2f * Time.fixedDeltaTime);
                }
                break;
        }
        
    }
}

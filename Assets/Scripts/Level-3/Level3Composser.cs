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
    [SerializeField]
    Sprite[] rocks;
    [SerializeField]
    GameObject fire, lightning, ice;


    private UnityEvent epochTrigger;

    void Start()
    {
        epoch = 0;
        progressBar.modifyProgress(-1);
        epochTrigger = new UnityEvent();
        epochTrigger.AddListener(TriggerEpoch);
        lightning.SetActive(false);
        fire.SetActive(false);
        ice.SetActive(false);
    }

    public void TriggerEpoch() 
    {
        epoch++;
        switch (epoch)
        {
            case 12:
                //Change to soccerball
                break;
            case 14:
                //change to bouncy ball
                break;
            case 16:
                //Lightning and fire! ON!
                fire.SetActive(false);
                lightning.SetActive(false);
                Invoke("turnOffLightning", 1f);
                break;
            case 18:
                fire.SetActive(false);
                break;
            case 19:
                ice.SetActive(true);
                break;
        }
    }

    private void turnOffLightning() 
    {
        lightning.SetActive(false);
    }

    public void ButtonPress(int from) 
    {
        if(from == 0) // Button
            switch (epoch)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 7:
                    progressBar.modifyProgress(0.02f);
                    narrator.Trigger(epochTrigger);
                    break;
                case 6:
                case 5:
                case 8:
                    progressBar.modifyProgress(0.02f);
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    progressBar.modifyProgress(0.01f);
                    break;
            }
        if (from == 1) // Fire
            switch (epoch) 
            {
                case 16:
                case 18:
                    narrator.Trigger(epochTrigger);
                    break;
            }
        if (from == 2) // Button (word)
            switch (epoch)
            {
                
            }
    }

    private void keepBetween(float min, float max) 
    {
        float progress = progressBar.GetProgress();
        float distance = max - min;
        if (progress > min) 
        {
            progressBar.modifyProgress(-0.1f * Time.fixedDeltaTime);
        }
        if (progress > min + (distance*0.25))
        {
            progressBar.modifyProgress(-0.2f * Time.fixedDeltaTime);
        }
        if (progress > min + (distance * 0.50))
        {
            progressBar.modifyProgress(-0.2f * Time.fixedDeltaTime);
        }
        if (progress > min + (distance * 0.75))
        {
            progressBar.modifyProgress(-0.2f * Time.fixedDeltaTime);
        }
    }

    private void FixedUpdate()
    {
        switch (epoch)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 7:
                keepBetween(0.10f * (epoch), 1);
                break;
            case 5:
            case 17:
                if (!narrator.IsTalking())
                    TriggerEpoch();
                keepBetween(0.10f * (epoch), 1);
                break;
            case 6:
            case 8:
            case 9:
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
                if (progressBar.GetProgress() > 0.5f)
                {
                    progressBar.modifyProgress(-1);
                    narrator.Trigger(epochTrigger);
                    Debug.Log("BaDonk!");
                }
                break;
            case 16:
                break;
        }
        
    }
}

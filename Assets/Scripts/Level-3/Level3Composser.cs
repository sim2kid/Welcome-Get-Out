using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level3Composser : MonoBehaviour
{
    [SerializeField]
    private int startAt;
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
    [SerializeField]
    Sprite[] icey;


    private int iceCount = 0;
    private int fireCount = 0;
    private float fireSize;
    private UnityEvent epochTrigger;

    void Start()
    {
        if (startAt != 0) {
            narrator.JumpToLine(startAt-1);
        } else {
            epoch = 0;
            startAt = 0;
        }
        fireSize = fire.transform.localScale.x;
        fireCount = 10;
        iceCount = icey.Length;
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
                fire.SetActive(true);
                lightning.SetActive(true);
                Invoke("turnOffLightning", 1f);
                break;
            case 18:
                fire.SetActive(false);
                narrator.JumpToLine(32);
                TriggerEpoch();
                break;
            case 20:
                narrator.Trigger();
                ice.SetActive(true);
                break;
            case 23:
                // Ice melt animation
                Debug.Log("Melt Melt Melt!");
                break;
            case 24:
                ice.SetActive(false);
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
                case 24:
                    progressBar.modifyProgress(0.05f);
                    break;
            }
        if (from == 1) // Fire
            switch (epoch) 
            {
                case 17:
                    reduceFire();
                    break;
            }
        if (from == 2) // Button (word)
            switch (epoch)
            {
                case 0:
                    break;
            }
        if (from == 3) // Button (Ice)
            switch (epoch)
            {
                case 21:
                    narrator.Trigger(epochTrigger);
                    break;
                case 23:
                    melt();
                    break;
            }
    }

    private void melt() 
    {
        iceCount--;
        if (iceCount == 0) {
            narrator.Trigger(epochTrigger);
            return;
        }
        SpriteRenderer sr = ice.GetComponent<SpriteRenderer>();
        sr.sprite = icey[iceCount - 1];
    }

    private void reduceFire() 
    {
        fireCount--;
        float newSize = (fireSize * fireCount) / 10;
        fire.transform.localScale = new Vector3(newSize, newSize, newSize);
        if (fireCount == 0) {
            TriggerEpoch();
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
                if (!narrator.IsTalking())
                    TriggerEpoch();
                keepBetween(0.10f * (epoch), 1);
                break;
            case 16:
                if(narrator.atIndex() == 28)
                    TriggerEpoch();
                break;
            case 20:
                if (narrator.atIndex() == 34)
                    TriggerEpoch();
                break;
            case 22:
                if (narrator.atIndex() == 38)
                    TriggerEpoch();
                break;
            case 23:
                if (narrator.atIndex() == 40 && !narrator.IsTalking())
                    TriggerEpoch();
                break;
            case 24:
                keepBetween(0.65f, 0.8f);
                if (narrator.atIndex() == 44 && !narrator.IsTalking())
                    TriggerEpoch();
                break;
            case 25:
                keepBetween(0.70f, 0.8f);
                break;
            case 19:
                if (!narrator.IsTalking())
                {
                    TriggerEpoch();
                }
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
        }
        
    }
}

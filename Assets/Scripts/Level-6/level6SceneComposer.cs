using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class level6SceneComposer : MonoBehaviour
{
    [SerializeField]
    SettingsController settings;
    [SerializeField]
    CheckMark musicSetting;
    [SerializeField]
    NarratorController narrator;
    [SerializeField]
    Coupling gearCouple;
    [SerializeField]
    DoorController door;
    [SerializeField]
    GearTrain train;

    [SerializeField]
    AudioClip song;
    AudioSource musicSource;

    public bool approchedMusic;
    private bool stopMusic;
    private bool gearPickup, machineFail, machineFix, touchCards, won;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = song;
        musicSource.loop = true;
        approchedMusic = false;
        stopMusic = false;
        gearPickup = machineFail = machineFix = touchCards = won = false;
    }

    void Update()
    {
        if (narrator.atIndex() == 6 && !narrator.IsTalking() && !settings.isMusicPlaying) 
        {
            PlayMusic();
        }
        if (narrator.atIndex() == 26 && narrator.IsOver()) 
        {
            nextLevel();
        }
        door.isMarching = train.IsEngaged;
    }

    public void PlayMusic() 
    {
        musicSetting.isTrue = true;
        musicSource.Play();
        settings.isMusicPlaying = true;
    }

    public void PickupGear() 
    {
        if (!gearPickup) 
        {
            gearPickup = true;
            narrator.JumpToLine(15);
        }
    }

    public void CheckGear() 
    {
        if (gearCouple.isCoupled)
            FixMachine();
        else
            FailToFixMachine();
    }

    public void FailToFixMachine()
    {
        if (!machineFail)
        {
            machineFail = true;
            narrator.JumpToLine(17);
        }
    }

    public void FixMachine()
    {
        if (!machineFix)
        {
            machineFail = true;
            machineFix = true;
            narrator.JumpToLine(20);
        }
    }

    public void DontTouchCards() 
    {
        if (!touchCards) 
        {
            touchCards = true;
            narrator.JumpToLine(22);
        }
    }

    public void GearFall() 
    {
        narrator.JumpToLine(9);
    }

    public void ApprochTurnDown() 
    {
        narrator.JumpToLine(10);
    }

    public void StopMusic() 
    {
        if (!musicSetting.isTrue && !stopMusic) 
        {
            stopMusic = true;
            narrator.JumpToLine(12);
            musicSource.Stop();
        }
    }

    public void Win() 
    {
        if (!won) 
        {
            won = true;
            narrator.JumpToLine(26);
        }
    }

    private void nextLevel() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level-7");
    }
}

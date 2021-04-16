using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    private DragConstraints settingsGear;
    [SerializeField]
    private SpriteGravity settingsGearGravity;
    [SerializeField]
    private GameObject settingsMenu;
    [SerializeField]
    private GameObject settingsButton;
    [SerializeField]
    private CheckMark musicSetting;
    [SerializeField]
    public bool Open;
    public bool isMusicPlaying;
    [SerializeField]
    level6SceneComposer sceneComposer;

    void Start()
    {
        settingsGear.enabled = false;
        settingsGearGravity.ToggleGravity(false);
        settingsButton.SetActive(true);
        Open = false;
        isMusicPlaying = false;
    }

    private void FixedUpdate()
    {
        settingsMenu.SetActive(Open);
        if (!isMusicPlaying)
        {
            musicSetting.isTrue = false;
        }
        else if (!musicSetting.isTrue && isMusicPlaying) 
        {
            sceneComposer.StopMusic();
        }
    }

    public void OpenMenu() 
    {
        Open = true;
        settingsMenu.SetActive(true);
        if (isMusicPlaying && !sceneComposer.approchedMusic) 
        {
            sceneComposer.approchedMusic = true;
            sceneComposer.ApprochTurnDown();
        }
    }

    public void CloseMenu()
    {
        Open = false;
        settingsMenu.SetActive(false);
        if (!musicSetting.isTrue && isMusicPlaying)
        {
            settingsGear.enabled = true;
            settingsButton.SetActive(false);
            settingsGearGravity.ToggleGravity(true);
            sceneComposer.GearFall();
        }
    }

    public void ToggleMenu()
    {
        if (Open)
            CloseMenu();
        else
            OpenMenu();
    }
}

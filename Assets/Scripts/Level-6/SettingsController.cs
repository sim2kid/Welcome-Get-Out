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

    void Start()
    {
        settingsGear.enabled = false;
        settingsGearGravity.ToggleGravity(false);
        settingsButton.SetActive(true);
        Open = false;
    }

    private void FixedUpdate()
    {
        settingsMenu.SetActive(Open);
    }

    public void OpenMenu() 
    {
        Open = true;
        settingsMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        Open = false;
        settingsMenu.SetActive(false);
        if (!musicSetting.isTrue)
        {
            settingsGear.enabled = true;
            settingsButton.SetActive(false);
            settingsGearGravity.ToggleGravity(true);
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

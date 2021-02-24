using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    public MouseState State 
    {
        get;
        private set;
    }
    
    
    void Start()
    {
        //Initialize Variables
        State = MouseState.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateMouseState(ClickType clickType) 
    {
        if (clickType == ClickType.Click) {
            Debug.Log("I've been clicked!");
        }
        if (clickType == ClickType.Unclick)
        {
            Debug.Log("Oh wait.. nvm...");
        }
    }
    public void OnEnter(ClickType clickType)
    {
        Debug.Log("A mouse entered while in state: " + clickType);
    }
    public void OnLeave(ClickType clickType) 
    {
        Debug.Log("A mouse left while in state: " + clickType);
    }
}

public enum MouseState {
    None, // Default State
    Hover, // While mouse is hovering (unclicked)
    Click, // When the mouse clicks down
    Hold, // When mouse is hovering (clicked)
    Drag, // When mouse is hovering, but held clicked first
    Release // when mouse clicks up
}
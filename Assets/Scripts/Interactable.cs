using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public SpriteMouseState State 
    {
        get;
        private set;
    }
    
    
    void Start()
    {
        //Initialize Variables
        State = SpriteMouseState.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum SpriteMouseState {
    None, // Default State
    Hover, // While mouse is hovering (unclicked)
    Click, // When the mouse clicks down
    Hold, // When mouse is hovering (clicked)
    Drag, // When mouse is hovering, but held clicked first
    Release // when mouse clicks up
}
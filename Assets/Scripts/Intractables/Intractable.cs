using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Intractable : MonoBehaviour, IIntractable
{
    private void OnEnable()
    {
        gameObject.layer = 9; // 9 is Intractable layer
    }
    public virtual void UpdateMouseState(ClickType clickType, Vector2 location) 
    {
        if (clickType == ClickType.Click) {
            OnClick();
        }
        if (clickType == ClickType.Unclick)
        {
            OnUnclick();
        }
    }

    //Event Responses
    public virtual void OnClick() 
    {
        //Debug.Log("I've been clicked!");
    }
    public virtual void OnUnclick() 
    {
        //Debug.Log("Oh wait.. nvm...");
    }
    public virtual void OnEnter(ClickType clickType)
    {
        //Debug.Log("A mouse entered while in state: " + clickType);
    }
    public virtual void OnLeave(ClickType clickType) 
    {
        //Debug.Log("A mouse left while in state: " + clickType);
    }
}
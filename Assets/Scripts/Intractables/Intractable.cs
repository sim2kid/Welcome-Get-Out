using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Intractable : MonoBehaviour, IIntractable
{
    private bool canFullClick;

    private void OnEnable()
    {
        gameObject.layer = 9; // 9 is Intractable layer
    }
    private void Start()
    {
        canFullClick = false;
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
        canFullClick = true;
    }
    public virtual void OnUnclick() 
    {
        if (canFullClick)
            OnFullClick();
        canFullClick = false;
    }
    public virtual void OnFullClick() 
    {

    }
    public virtual void OnEnter(ClickType clickType)
    {
        
    }
    public virtual void OnLeave(ClickType clickType) 
    {
        canFullClick = false;
    }
}
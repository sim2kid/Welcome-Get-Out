using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Intractable : MonoBehaviour, IIntractable
{
    private bool canFullClick;
    [SerializeField]
    private UnityEvent m_onClick;
    [SerializeField]
    private UnityEvent m_onUnclick;
    [SerializeField]
    private UnityEvent m_onFullClick;
    [SerializeField]
    private UnityEvent m_onEnter;
    [SerializeField]
    private UnityEvent m_onLeave;

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
        m_onClick.Invoke();
    }
    public virtual void OnUnclick() 
    {
        if (canFullClick)
            OnFullClick();
        canFullClick = false;
        m_onUnclick.Invoke();
    }
    public virtual void OnFullClick() 
    {
        m_onFullClick.Invoke();
    }
    public virtual void OnEnter(ClickType clickType)
    {
        m_onEnter.Invoke();
    }
    public virtual void OnLeave(ClickType clickType) 
    {
        canFullClick = false;
        m_onLeave.Invoke();
    }
}
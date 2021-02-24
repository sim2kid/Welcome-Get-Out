using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[DisallowMultipleComponent]
public class MouseManager : MonoBehaviour
{
    private PlayerInput m_PlayerInput;
    private InputAction m_LocationAction;
    private InputAction m_HoldAction;

    private ClickType click;

    private void Start()
    {
        click = ClickType.Clear;
    }

    private void FixedUpdate()
    {
        if (m_PlayerInput == null) 
        {
            m_PlayerInput = GetComponent<PlayerInput>();
            m_LocationAction = m_PlayerInput.actions["Location"];
            m_HoldAction = m_PlayerInput.actions["Hold"];
        }

        Vector2 screenLocation = m_LocationAction.ReadValue<Vector2>();
        var hold = m_HoldAction.ReadValue<float>();

        if (click == ClickType.Unclick)
        {
            click = ClickType.Clear;
        }
        if (click == ClickType.Click)
        {
            click = ClickType.Hold;
        }

        if (click == ClickType.Clear && hold > 0) 
        {
            click = ClickType.Click;
        }
        if (click == ClickType.Hold && hold == 0)
        {
            click = ClickType.Unclick;
        }

        //Debug.Log("Click: " + click + ", Hold: " + hold + ", Location: (" + screenLocation.x + ", " + screenLocation.y + ")");
    }
}

enum ClickType 
{
    Click,
    Hold,
    Unclick,
    Clear
}

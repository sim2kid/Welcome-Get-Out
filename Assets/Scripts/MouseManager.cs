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

    private ClickType m_Click;
    private GameObject lastHit;

    [SerializeField]
    private Transform topRight;

    public Vector2 MouseLocation => 
        Camera.main.ScreenToWorldPoint(m_LocationAction.ReadValue<Vector2>());
    public ClickType Click => m_Click;

    private int layerMask;

    private void Start()
    {
        m_Click = ClickType.Clear;
        lastHit = null;
        layerMask = 1 << 9;
    }

    private void FixedUpdate()
    {
        if (m_PlayerInput == null) 
        {
            m_PlayerInput = GetComponent<PlayerInput>();
            m_LocationAction = m_PlayerInput.actions["Location"];
            m_HoldAction = m_PlayerInput.actions["Hold"];
        }

        Vector2 lowerLimits = Vector2.zero;
        Vector2 upperLimits = Camera.main.WorldToScreenPoint(topRight.position);

        Vector2 screenLocation = m_LocationAction.ReadValue<Vector2>();
        screenLocation.x = Mathf.Clamp(screenLocation.x, lowerLimits.x, upperLimits.x);
        screenLocation.y = Mathf.Clamp(screenLocation.y, lowerLimits.y, upperLimits.y);

        var hold = m_HoldAction.ReadValue<float>();

        if (m_Click == ClickType.Unclick)
        {
            m_Click = ClickType.Clear;
        }
        if (m_Click == ClickType.Click)
        {
            m_Click = ClickType.Hold;
        }

        if (m_Click == ClickType.Clear && hold > 0) 
        {
            m_Click = ClickType.Click;
        }
        if (m_Click == ClickType.Hold && hold == 0)
        {
            m_Click = ClickType.Unclick;
        }

        notifyObject(m_Click, screenLocation);

        //Debug.Log("Click: " + click + ", Hold: " + hold + ", Location: (" + screenLocation.x + ", " + screenLocation.y + ")");
    }

    private void notifyObject(ClickType clickEvent, Vector2 screenLocation)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenLocation);
        RaycastHit hit;
        GameObject obj;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            obj = hit.transform.gameObject;
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);

            if (obj != null)
            {
                if (lastHit != obj) 
                {
                    if (lastHit != null)
                    {
                        foreach(IIntractable lsht in lastHit.GetComponents<IIntractable>())
                            lsht.OnLeave(clickEvent);
                    }
                    foreach (IIntractable obb in obj.GetComponents<IIntractable>())
                        obb.OnEnter(clickEvent);
                    lastHit = obj;
                }
                foreach (IIntractable obb in obj.GetComponents<IIntractable>())
                    obb.UpdateMouseState(clickEvent, Camera.main.ScreenToWorldPoint(screenLocation));
            }
        }
        else 
        {
            Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
            if (lastHit != null) 
            {
                foreach (IIntractable lsht in lastHit.GetComponents<IIntractable>())
                    lsht.OnLeave(clickEvent);
                lastHit = null;
            }
        }
    } 
}

public enum ClickType 
{
    Click,
    Hold,
    Unclick,
    Clear
}

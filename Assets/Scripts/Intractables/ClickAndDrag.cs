﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickAndDrag : Intractable
{
    private bool isHolding;
    protected bool blockClick;
    protected Vector2 offset;
    protected MouseManager mouse;

    private Vector2 startPos;
    private float tolerance = 0.1f;

    [SerializeField]
    private UnityEvent m_onDrag;
    [SerializeField]
    private UnityEvent m_onDrop;

    private void OnEnable()
    {
        mouse = FindObjectOfType<MouseManager>();
    }

    private void Start()
    {
        isHolding = false;
        blockClick = false;
        offset = Vector2.zero;
    }

    private void Update()
    {
        if (isHolding)
        {
            OnHolding();
        }
    }

    protected virtual void OnHolding() 
    {
        if (!blockClick)
        {
            if (Vector2.Distance(this.startPos, this.transform.position) > this.tolerance)
            {
                blockClick = true;
                m_onDrag.Invoke();
            }
        }
        if (mouse.Click == ClickType.Clear)
        {
            OnUnclick();
        }
    }

    public override void OnClick()
    {
        isHolding = true;
        startPos = transform.position;
        offset = (Vector2)transform.position - mouse.MouseLocation;
        base.OnClick();
    }

    public override void OnUnclick()
    {
        if (isHolding)
        {
            if(!blockClick)
                m_onDrop.Invoke();
        }
        isHolding = false;
        offset = Vector2.zero;
        base.OnUnclick();

        if (blockClick) {
            blockClick = false;
            m_onDrop.Invoke();
        }
    }

    public override void OnEnter(ClickType clickType)
    {
        if (clickType == ClickType.Clear) 
        {
            OnUnclick();
        }
        base.OnEnter(clickType);
    }
}

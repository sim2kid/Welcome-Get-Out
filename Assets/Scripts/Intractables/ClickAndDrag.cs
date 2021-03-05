using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : Intractable
{
    private bool isHolding;
    private Vector2 offset;
    private MouseManager mouse;

    private void OnEnable()
    {
        mouse = FindObjectOfType<MouseManager>();
    }

    private void Start()
    {
        isHolding = false;
        offset = Vector2.zero;
    }

    private void Update()
    {
        if (isHolding)
            transform.position = mouse.MouseLocation + offset;
    }

    public override void OnClick()
    {
        isHolding = true;
        offset = (Vector2)transform.position - mouse.MouseLocation;
    }

    public override void OnUnclick()
    {
        isHolding = false;
        offset = Vector2.zero;
    }

    public override void OnEnter(ClickType clickType)
    {
        if (clickType == ClickType.Clear) 
        {
            OnUnclick();
        }
    }
}

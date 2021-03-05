using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : Intractable
{
    private bool isHolding;
    protected Vector2 offset;
    protected MouseManager mouse;

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
        {
            OnHolding();
        }
    }

    protected virtual void OnHolding() 
    {
        Vector2 newPos = mouse.MouseLocation + offset;
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
        if (mouse.Click == ClickType.Clear)
        {
            OnUnclick();
        }
    }

    public override void OnClick()
    {
        isHolding = true;
        offset = (Vector2)transform.position - mouse.MouseLocation;
        base.OnClick();
    }

    public override void OnUnclick()
    {
        isHolding = false;
        offset = Vector2.zero;
        base.OnUnclick();
    }

    public override void OnEnter(ClickType clickType)
    {
        if (clickType == ClickType.Clear) 
        {
            OnUnclick();
        }
    }
}

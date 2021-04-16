using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MirrorAsset : DragConstraints
{
    [SerializeField]
    private Vector2 mirrorOffset;
    [SerializeField]
    private GameObject other;
    [SerializeField]
    private bool clickable;
    [SerializeField]
    private UnityEvent onClickEvent;

    protected override void OnHolding()
    {
        base.OnHolding();
        moveOther();
    }

    private void moveOther() 
    {
        bool onRight = transform.position.x < 0;
        other.transform.position = new Vector3(transform.position.x + (onRight ? mirrorOffset.x : -mirrorOffset.x), transform.position.y + mirrorOffset.y, transform.position.z);
    }

    public void ForceMoveUpdate() 
    {
        moveOther();
    }

    public override void OnFullClick()
    {
        if (clickable && !blockClick)
        {
            onClickEvent.Invoke();
        }
        base.OnFullClick();
    }
}

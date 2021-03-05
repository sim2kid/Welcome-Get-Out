using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragConstraints : ClickAndDrag
{
    private Vector2 constrainedValues;

    [Header("Constrain Axis")]
    [SerializeField]
    bool x, y;
    private void Start()
    {
        constrainedValues = transform.position;
    }

    protected override void OnHolding()
    {
        Vector2 newPos = mouse.MouseLocation + offset;
        transform.position = new Vector3((x ? constrainedValues.x : newPos.x), (y ? constrainedValues.y : newPos.y), transform.position.z);
        if (mouse.Click == ClickType.Clear)
        {
            OnUnclick();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragConstraints : ClickAndDrag
{
    private Vector2 constrainedValues;

    [Header("Constrain Axis")]
    [SerializeField]
    public bool x, y;
    private void Start()
    {
        constrainedValues = transform.position;
    }

    protected override void OnHolding()
    {
        Vector2 newPos = mouse.MouseLocation + offset;
        transform.position = new Vector3((x ? constrainedValues.x : newPos.x), (y ? constrainedValues.y : newPos.y), transform.position.z);

        base.OnHolding();
    }
}

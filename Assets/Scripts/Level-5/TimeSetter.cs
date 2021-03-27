using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSetter : Intractable
{
    [SerializeField]
    private Vector2 fixedLocation;
    [SerializeField]
    ClockController clock;
    private bool isHolding;

    public override void UpdateMouseState(ClickType clickType, Vector2 location)
    {
        this.fixedLocation = location - (Vector2)transform.position;
        base.UpdateMouseState(clickType, location);
    }

    public override void OnEnter(ClickType clickType)
    {
        if (clickType == ClickType.Clear)
            OnUnclick();
        base.OnEnter(clickType);
    }

    public override void OnUnclick()
    {
        isHolding = false;
        base.OnUnclick();
    }

    public override void OnClick()
    {
        isHolding = true;
        base.OnClick();
    }

    private void Update()
    {
        if (isHolding)
            OnHolding();
    }

    private void OnHolding() 
    {
        float ourAngle = radiansToRotation(locToRadians());
        float clockAngle = clock.MinuteAngle;
        float newAngle = ourAngle - clockAngle;

        if (newAngle > 180) 
        {
            newAngle -= 360;
        }
        if (newAngle <= -180) 
        {
            newAngle += 360;
        }

        clock.ModifyMinute(newAngle / 6);
        //Debug.Log(newAngle);

    }

    private float radiansToRotation(float rad) 
    {
        rad = rad * (180 / Mathf.PI);
        rad -= 90;
        rad = 360 - rad;

        if (rad >= 360) {
            rad -= 360;
        }
        if (rad < 0) {
            rad += 360;
        }

        return rad;
    }

    private float locToRadians() 
    {
        Vector2 normPos = fixedLocation.normalized;
        float x = Mathf.Acos(normPos.x);
        float y = Mathf.Asin(normPos.y);
        //Debug.Log($"({normPos.x}, {normPos.y}) ({x / Mathf.PI}PI, {y / Mathf.PI}PI)"); //x iso our rotaiton halfs.
        if (y >= 0)
        {
            return x;
        }
        else
        {
            return (2 * Mathf.PI) - x;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSpinner : MonoBehaviour
{
    [SerializeField]
    private bool goClockwise;
    [SerializeField]
    private float rpm;
    [SerializeField]
    public bool IsActive;
    [SerializeField]
    public bool IsEngaged;

    void Update()
    {
        if (IsActive)
            this.transform.Rotate(new Vector3(0, 0, rpm * 6 * Time.deltaTime * (goClockwise ? -1 : 1)));
    }

    public void SetIsEngaged(bool torf)
    {
        IsEngaged = torf;
    }

    public void SetAcctive (bool torf) 
    {
        IsActive = torf;
    }
}

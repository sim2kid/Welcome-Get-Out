using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearTrain : MonoBehaviour
{
    [SerializeField]
    private List<GearSpinner> train;

    public bool IsEngaged;
    private void Awake()
    {
        IsEngaged = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool lastEngaged = true;
        foreach (GearSpinner gear in train) 
        {
            if (lastEngaged && gear.IsEngaged)
            {
                gear.IsActive = true;
                lastEngaged = true;
            }
            else 
            {
                gear.IsActive = false;
                lastEngaged = false;
            }
        }
        IsEngaged = lastEngaged;
    }
}

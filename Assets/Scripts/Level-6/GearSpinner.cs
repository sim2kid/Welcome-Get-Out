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
    public bool shake;

    void Update()
    {
        if (shake)
            goClockwise = !goClockwise;
        this.transform.Rotate(new Vector3(0, 0, rpm * 6 * Time.deltaTime * (goClockwise ? -1 : 1)));
    }

    public void Shake(bool torf) 
    {
        shake = torf;
    }
}

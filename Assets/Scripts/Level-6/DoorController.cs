using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    float marchRate;
    [SerializeField]
    Vector2 desiredLocation;

    public bool isMarching;

    void Start()
    {
        isMarching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMarching) 
        {
            transform.position += (Vector3)(desiredLocation - (Vector2)transform.position).normalized * marchRate * Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorController : MonoBehaviour
{
    [SerializeField]
    float marchRate;
    [SerializeField]
    Vector2 desiredLocation;

    [SerializeField]
    public UnityEvent OnMarch, OnHault;

    public bool isMarching;
    bool lastMarch;
    

    void Start()
    {
        isMarching = false;
        lastMarch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMarching) 
        {
            transform.position += (Vector3)(desiredLocation - (Vector2)transform.position).normalized * marchRate * Time.deltaTime;
            if (Mathf.Sqrt((desiredLocation - (Vector2)transform.position).SqrMagnitude()) < 0.1f) 
            {
                isMarching = false;
            }
        }
        if (lastMarch != isMarching) 
        {
            if (isMarching)
            {
                OnMarch.Invoke();
            }
            else 
            {
                OnHault.Invoke();
            }
            lastMarch = isMarching;
        }
    }
}

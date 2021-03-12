using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnCollision : MonoBehaviour
{
    [SerializeField]
    private UnityEvent callThis;
    private void OnTriggerEnter(Collider other)
    {
        callThis.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coupling : MonoBehaviour
{
    [SerializeField]
    GameObject toBindto;
    [SerializeField]
    float radius;
    [SerializeField]
    float uncoupleOffset;
    [SerializeField]
    UnityEvent onCouple;
    [SerializeField]
    UnityEvent onUnCouple;
    public bool isCoupled;

    private void Start()
    {
        isCoupled = false;
        TryToCouple();
    }

    public void TryToCouple() 
    {
        if (((Vector2)toBindto.transform.position
            - (Vector2)transform.position).magnitude <= radius) 
        {
            Couple();
        }
    }

    public void Couple() 
    {
        isCoupled = true;
        toBindto.transform.parent = this.transform;
        toBindto.transform.localPosition = Vector3.zero;
        toBindto.transform.localRotation = new Quaternion();
        onCouple.Invoke();
    }
    public void UnCouple()
    {
        isCoupled = false;
        toBindto.transform.parent = this.transform.parent;
        toBindto.transform.position = new Vector3(toBindto.transform.position.x,
            toBindto.transform.position.y, transform.position.z + uncoupleOffset);
        onUnCouple.Invoke();
    }
}

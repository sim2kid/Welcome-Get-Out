using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteGravity : MonoBehaviour
{
    [SerializeField]
    float sudoFloor;
    [SerializeField]
    bool useSudoFloor;
    [SerializeField]
    float speed;
    [SerializeField]
    [Range(0f,1f)]
    float bounce;
    [SerializeField]
    bool useGravity;
    [SerializeField]
    UnityEvent onGroundHit;
    [SerializeField]
    float hitTollarance;

    Vector2 velocity;
    Vector3 lastPos;
    Vector2 positionalVelocity;

    public void ResetVelocity() 
    {
        velocity = new Vector2(0, 0);
    }

    public void ToggleGravity(bool toggle) 
    {
        useGravity = toggle;
        if (!useGravity) 
        {
            ResetVelocity();
        }
    }
    public void ToggleGravity()
    {
        useGravity = !useGravity;
    }

    private void Start()
    {
        ResetVelocity();
    }

    public void UseStoredVelocity() 
    {
        velocity = positionalVelocity;
    }


    void Update()
    {
        //positionalVelocity = (transform.position - lastPos);
        //Debug.Log(positionalVelocity);
        //lastPos = this.transform.position;

        if (useGravity)
            velocity.y += speed * Time.deltaTime;
        this.transform.position += new Vector3(velocity.x, -velocity.y * Time.deltaTime, 0);
        if (transform.position.y < sudoFloor && useSudoFloor) 
        {
            transform.position = new Vector3(transform.position.x, sudoFloor, transform.position.z);
            if (Mathf.Abs(velocity.y) >= hitTollarance)
                onGroundHit.Invoke();
            velocity.y *= -bounce;
        }
    }

    private void OnDrawGizmos()
    {
        if(useSudoFloor)
            Debug.DrawLine(new Vector3(-20, sudoFloor, 5), new Vector3(20, sudoFloor, 5));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeChecker : MonoBehaviour
{
    [SerializeField]
    List<Coupling> codeBlocks;

    [SerializeField]
    float endLocation;
    float ogLocation;
    [SerializeField]
    float step;
    [SerializeField]
    bool isRelocating;

    private void Start()
    {
        isRelocating = false;
        ogLocation = transform.position.y;
        relocateCode();
    }

    private void Update()
    {
        if (isRelocating) 
        {
            if (Mathf.Abs(transform.position.y - endLocation) > 0.1)
            {
                float moveby = step * ((endLocation > transform.position.y) ? 1 : -1) * Time.deltaTime;
                transform.position = new Vector3(transform.position.x, moveby + transform.position.y, transform.position.z);
                foreach (Coupling mount in codeBlocks) 
                {
                    Transform otherTF = mount.gameObject.transform;
                    otherTF.position = new Vector3(otherTF.position.x, moveby + otherTF.position.y, otherTF.position.z);
                }
            }
            else 
            {
                isRelocating = false;
                float temp = ogLocation;
                ogLocation = endLocation;
                endLocation = temp;
            }
        }
    }

    public int codeFixedAmount() 
    {
        int fixedBlocks = 0;
        foreach (Coupling c in codeBlocks) 
        {
            if (c.isCoupled)
                fixedBlocks++;
        }
        return fixedBlocks++;
    }

    public void relocateCode() 
    {
        
    }
}

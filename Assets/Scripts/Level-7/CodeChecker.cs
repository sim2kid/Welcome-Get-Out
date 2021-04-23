using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeChecker : MonoBehaviour
{
    [SerializeField]
    List<Coupling> codeBlocks;

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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField]
    private BoxFacing facing;
    [SerializeField]
    private GameObject[] faces;
    
    void Start()
    {
        facing = BoxFacing.Forward;
        UpdateFace();
    }

    private void UpdateFace() 
    {
        for (int i = 0; i < faces.Length; i++) 
        {
            faces[i].SetActive(((i)==(int)facing)?true:false);
        }
    }

    public void TurnLeft() 
    {
        int temp = (int)facing - 1;
        if (temp < 0)
        {
            temp += faces.Length;
        }

        facing = (BoxFacing)temp;
        UpdateFace();
    }

    public void TurnRight() 
    {
        int temp = (int)facing + 1;
        if (temp >= faces.Length) 
        {
            temp -= faces.Length;
        }

        facing = (BoxFacing)temp;
        UpdateFace();
    }
}

public enum BoxFacing 
{
    Forward = 0,
    Right = 1,
    Back = 2,
    Left = 3
}

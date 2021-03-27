using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DigitalTime : MonoBehaviour
{
    [SerializeField]
    TextMeshPro text;
    [SerializeField]
    ClockController clock;

    private void Update()
    {
        text.text = clock.m_Time;
    }
}

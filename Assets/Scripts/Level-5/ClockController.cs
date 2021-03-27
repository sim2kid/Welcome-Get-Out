using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    [SerializeField]
    public string m_Time;

    [SerializeField]
    [Range(1f, 3600f)]
    float modifier;

    [SerializeField]
    GameObject second, minute, hour;

    float minTime, secTime, hourTime, amPM;

    public int mTime
    {
        private set;
        get;
    }
    public int hTime
    {
        private set;
        get;
    }

    public float MinuteAngle 
    {
        get { return minTime * 6; }
    }

    bool minPause;

    float minuteToRotation(float min) 
    {
        min *= 6; // out of 60 -> out of 360
        min = -min; // Invert to match unity rotation;
        min += 180; // The hands point at 6 instead of 12, so we add half a rotaion
        return min;
    }

    float hourToRotation(float hours, float min)
    {
        hours *= 30; // out of 12 -> out of 360
        min /= 2; // out of 60 -> out of 30 (which is an hour)

        var together = hours + min;
        together = -together; // Invert to match rotation
        together += 180;
        return together;
    }

    void setRotation(GameObject obj, float rotation) 
    {
        obj.transform.rotation = Quaternion.Euler(obj.transform.rotation.x, obj.transform.rotation.y, rotation);
    }

    public void ModifyMinute(float amount) 
    {
        // Amount should be between -30 and 30
        minTime += amount;
    }

    public void PauseMinute(bool torf) 
    {
        minPause = torf;
    }

    void Start()
    {
        modifier = 1;
        SetTime(Random.Range(0,24), Random.Range(0, 60), System.DateTime.Now.Second);
        minPause = false;
    }

    public void SetTime(float hou, float min, float sec) 
    {
        secTime = sec;
        minTime = min;
        amPM = 0;
        if (hourTime > 12) 
        {
            hourTime -= 12;
            amPM = 1;
        }
        hourTime = hou;
    }

    private void FixedUpdate()
    {
        secTime += Time.fixedDeltaTime * modifier;
        if (secTime >= 60) {
            secTime -= 60;
            if(!minPause)
                minTime++;
        }

        if (minTime >= 60) {
            minTime -= 60;
            hourTime++;
        }
        if (minTime < 0) {
            minTime += 60;
            hourTime--;
        }


        if (hourTime > 12)
        {
            hourTime -= 12;
            amPM--;
        }
        if (hourTime <= 0)
        {
            hourTime += 12;
            amPM++;
        }

        if (amPM > 1) 
        {
            amPM = 0;
        }
        if (amPM < 0)
        {
            amPM = 1;
        }

        setRotation(second, minuteToRotation(secTime));
        setRotation(minute, minuteToRotation(minTime));
        setRotation(hour, hourToRotation(hourTime, minTime));

        float trueHour = hourTime + (amPM * 12);
        if (trueHour >= 24) {
            trueHour -= 24;
        }
        hTime = (int)trueHour;
        mTime = (int)minTime;

        m_Time = $"{((int)trueHour).ToString("D2")}:{((int)minTime).ToString("D2")}:{((int)secTime).ToString("D2")}";
    }
}

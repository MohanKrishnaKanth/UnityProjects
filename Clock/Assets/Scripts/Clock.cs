using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public Transform hoursArm, minutesArm, secondsArm;
    const float degreesPerHour = 30f;
    const float degreesPerMinuteAndSeconds = 6f;

    // Update is called once per frame
    void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursArm.transform.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
        minutesArm.transform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinuteAndSeconds, 0f);
        secondsArm.transform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerMinuteAndSeconds, 0f);
        
    }
}

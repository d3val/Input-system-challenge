using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    double timer;
    public TextMeshProUGUI timerText;
    public void ResetTimer()
    {
        timer = 0;
        timerText.text = ConvertTimerToString(timer);
    }

    string ConvertTimerToString(double value)
    {
        int hours, minutes, seconds, miliseconds;
        seconds = (int)value % 60;
        hours = (int)value / 3600;
        minutes = (int)(value - hours * 3600) / 60;
        miliseconds = (int)((value - Math.Truncate(value)) * 100);
        string s = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", hours, minutes, seconds, miliseconds);
        return s;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        timerText.text = ConvertTimerToString(timer);
    }

    private void OnEnable()
    {
        ResetTimer();
    }
}

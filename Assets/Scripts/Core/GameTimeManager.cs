using UnityEngine;
using System;

public class GameTimeManager : MonoBehaviour
{
    public static GameTimeManager Instance;

    public int hour = 6;
    public int minute = 0;

    public float realSecondsPerGameMinute = 1f;

    private float timer;

    public event Action OnTimeChanged;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= realSecondsPerGameMinute)
        {
            timer = 0;
            AddMinute(1);
        }
    }

    public void AddMinute(int amount)
    {
        minute += amount;

        if (minute >= 60)
        {
            minute = 0;
            hour++;

            if (hour >= 24)
                hour = 0;
        }

        OnTimeChanged?.Invoke();
    }

    public void AddHour(int amount)
    {
        hour += amount;

        if (hour >= 24)
            hour %= 24;

        OnTimeChanged?.Invoke();
    }

    public string GetTimeString()
    {
        return hour.ToString("00") + ":" + minute.ToString("00");
    }
}
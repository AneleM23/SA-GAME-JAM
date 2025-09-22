using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text timerText;

    private float elapsedTime = 0f;
    private bool running = false;

    public float ElapsedTime => elapsedTime;
    public bool IsRunning => running;

    private void Awake()
    {
        UpdateTimerText(0f);
        running = false; // Start only when told (LevelIntro/Tutorial will start it)
    }

    private void Update()
    {
        if (!running) return;
        elapsedTime += Time.deltaTime;
        UpdateTimerText(elapsedTime);
    }

    private void UpdateTimerText(float time)
    {
        if (timerText != null) timerText.text = FormatTime(time);
    }

    public void StartTimer()
    {
        running = true;
    }

    public void StopTimer()
    {
        running = false;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimerText(0f);
    }

    // mm:ss.hh (hundredths)
    public static string FormatTime(float t)
    {
        int minutes = Mathf.FloorToInt(t / 60f);
        int seconds = Mathf.FloorToInt(t % 60f);
        int hundredths = Mathf.FloorToInt((t * 100f) % 100f);
        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, hundredths);
    }
}

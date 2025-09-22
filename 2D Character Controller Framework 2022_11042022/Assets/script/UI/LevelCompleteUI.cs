using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteUI : MonoBehaviour
{
   [Header("Panel")]
    [SerializeField] private GameObject panel; // LevelCompletePanel
    [SerializeField] private Text finalTimeText;
    [SerializeField] private Text bestTimeText;
    [SerializeField] private GameObject newRecordTextObject;

    [Header("References")]
    [SerializeField] private TimerUI timer;
    [SerializeField] private HighScoreManager highScoreManager;

    private void Start()
    {
        if (panel != null) panel.SetActive(false);
        if (newRecordTextObject != null) newRecordTextObject.SetActive(false);
    }

    // Call this when level is finished (player reached point B)
    public void ShowLevelComplete()
    {
        if (timer != null) timer.StopTimer();
        float final = timer != null ? timer.ElapsedTime : 0f;

        if (panel != null) panel.SetActive(true);

        if (finalTimeText != null) finalTimeText.text = "Time: " + TimerUI.FormatTime(final);

        bool isNew = highScoreManager != null ? highScoreManager.TrySetBest(final) : false;

        float best = highScoreManager != null ? highScoreManager.GetBestTime() : -1f;
        if (bestTimeText != null)
            bestTimeText.text = best < 0f ? "Best: --:--.--" : "Best: " + TimerUI.FormatTime(best);

        if (newRecordTextObject != null) newRecordTextObject.SetActive(isNew);

        // Pause game (use timescale = 0 so everything stops)
        Time.timeScale = 0f;
    }

    // Button handlers
    public void OnNextLevel()
    {
        Time.timeScale = 1f;
        int idx = SceneManager.GetActiveScene().buildIndex;
        int next = idx + 1;
        if (next < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(next);
        else
            SceneManager.LoadScene(0); // fallback to main menu
    }

    public void OnRetry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

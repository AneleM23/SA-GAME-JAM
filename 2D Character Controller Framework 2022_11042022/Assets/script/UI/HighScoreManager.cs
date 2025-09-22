using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] private Text bestTimeText;

    private string key;

    private void Awake()
    {
        key = "BestTime_" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        UpdateUI();
    }

    public void UpdateUI()
    {
        float best = PlayerPrefs.GetFloat(key, -1f);
        if (best < 0f)
            bestTimeText.text = "Best: --:--.--";
        else
            bestTimeText.text = "Best: " + TimerUI.FormatTime(best);
    }

    // Returns true if new record
    public bool TrySetBest(float time)
    {
        float best = PlayerPrefs.GetFloat(key, -1f);
        if (best < 0f || time < best)
        {
            PlayerPrefs.SetFloat(key, time);
            PlayerPrefs.Save();
            UpdateUI();
            return true;
        }
        return false;
    }

    // Utility to read best externally
    public float GetBestTime()
    {
        return PlayerPrefs.GetFloat(key, -1f);
    }
}

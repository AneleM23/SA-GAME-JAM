using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelIntro : MonoBehaviour
{
    [SerializeField] private GameObject panel; // LevelIntroPanel (set active false)
    [SerializeField] private Text levelNameText;
    [SerializeField] private float displayDuration = 1.6f;
    [SerializeField] private MonoBehaviour[] disableDuringIntro; // player scripts to disable
    [SerializeField] private TimerUI timerToStart; // assign TimerUI here (optional)

    private CanvasGroup cg;

    private void Awake()
    {
        if (panel == null) return;
        cg = panel.GetComponent<CanvasGroup>();
        if (cg == null) cg = panel.AddComponent<CanvasGroup>();
        panel.SetActive(false);
    }

    private IEnumerator Start()
    {
        // show level name (scene name by default)
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (levelNameText != null) levelNameText.text = sceneName;

        // disable controls
        foreach (var c in disableDuringIntro) if (c != null) c.enabled = false;

        panel.SetActive(true);
        yield return StartCoroutine(Fade(0f, 1f, 0.25f));
        yield return new WaitForSecondsRealtime(displayDuration);
        yield return StartCoroutine(Fade(1f, 0f, 0.25f));
        panel.SetActive(false);

        // re-enable controls
        foreach (var c in disableDuringIntro) if (c != null) c.enabled = true;

        // start timer after intro
        if (timerToStart != null)
        {
            timerToStart.ResetTimer();
            timerToStart.StartTimer();
        }
    }

    private IEnumerator Fade(float from, float to, float dur)
    {
        float t = 0f;
        while (t < dur)
        {
            t += Time.unscaledDeltaTime;
            cg.alpha = Mathf.Lerp(from, to, t / dur);
            yield return null;
        }
        cg.alpha = to;
    }
}

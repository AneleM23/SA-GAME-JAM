using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    [SerializeField] private LevelCompleteUI levelCompleteUI;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (levelCompleteUI == null) 
            levelCompleteUI = FindObjectOfType<LevelCompleteUI>();

        // ✅ Show UI only, do NOT auto load the next level
        levelCompleteUI?.ShowLevelComplete();
    }
}

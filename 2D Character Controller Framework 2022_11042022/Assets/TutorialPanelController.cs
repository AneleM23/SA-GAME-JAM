using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPanelController : MonoBehaviour
{
    public GameObject tutorialPanel; // Assign your TutorialPanel in Inspector

    void Start()
    {
        // Only show tutorial panel if this is the Tutorial Scene
        if (SceneManager.GetActiveScene().name == "Tutorial") // <-- Replace with your exact scene name
        {
            tutorialPanel.SetActive(true);
        }
        else
        {
            tutorialPanel.SetActive(false);
        }
    }

    // Call this from the Skip button
    public void SkipTutorial()
    {
        tutorialPanel.SetActive(false);
    }
}

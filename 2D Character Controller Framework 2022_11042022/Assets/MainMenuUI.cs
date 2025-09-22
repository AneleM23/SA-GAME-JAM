using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void OnPlay()
    {
        // Load the first playable level (after Tutorial)
        SceneManager.LoadScene(1); // Assuming 0 = MainMenu, 1 = Tutorial
    }

    public void OnLevelSelect()
    {
        // Optional: load a Level Select scene (or just go to Tutorial for now)
        SceneManager.LoadScene("LevelSelect"); 
    }

    public void OnQuit()
    {
        Debug.Log("Quit pressed!");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

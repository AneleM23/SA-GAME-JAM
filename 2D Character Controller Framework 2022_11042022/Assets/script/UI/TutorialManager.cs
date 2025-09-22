using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private Text instructionText;
    [SerializeField] private float stepDelay = 0.15f;

    private void Start()
    {
        if (tutorialPanel != null) StartCoroutine(RunTutorial());
    }

    private IEnumerator RunTutorial()
    {
        tutorialPanel.SetActive(true);

        // Step 1: Move right
        instructionText.text = "Use A / D or ← → to move.\nPress D or → to continue.";
        yield return WaitForKeys(new KeyCode[] { KeyCode.D, KeyCode.RightArrow });

        instructionText.text = "Nice! Now press A or ← to move left.";
        yield return WaitForKeys(new KeyCode[] { KeyCode.A, KeyCode.LeftArrow });

        // Step 2: Jump
        instructionText.text = "Press Space to jump.";
        yield return WaitForKeys(new KeyCode[] { KeyCode.Space });

        // Step 3: Aim (mouse movement)
        instructionText.text = "Move the mouse to aim the cursor.";
        yield return WaitForMouseMovement();

        // Step 4: Shoot
        instructionText.text = "Click Left Mouse Button to shoot and create a temporary platform.";
        yield return WaitForMouseButton(0);

        // Final hint
        instructionText.text = "Good job! Use your paint shots to create platforms and reach the goal.";
        yield return new WaitForSeconds(1.0f);

        tutorialPanel.SetActive(false);
    }

    private IEnumerator WaitForKeys(KeyCode[] keys)
    {
        bool done = false;
        while (!done)
        {
            foreach (var k in keys) if (Input.GetKeyDown(k)) { done = true; break; }
            yield return null;
        }
        yield return new WaitForSeconds(stepDelay);
    }

    private IEnumerator WaitForMouseMovement()
    {
        Vector3 start = Input.mousePosition;
        while (Vector3.Distance(start, Input.mousePosition) < 5f) yield return null;
        yield return new WaitForSeconds(stepDelay);
    }

    private IEnumerator WaitForMouseButton(int button)
    {
        while (!Input.GetMouseButtonDown(button)) yield return null;
        yield return new WaitForSeconds(stepDelay);
    }
}

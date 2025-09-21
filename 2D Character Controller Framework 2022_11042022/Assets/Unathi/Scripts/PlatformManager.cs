using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance;   // Singleton access

    public int maxPlatforms = 3;              // Limit to 3 active platforms
    [SerializeField] private Queue<GameObject> activePlatforms = new Queue<GameObject>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegisterPlatform(GameObject platform)
    {
        activePlatforms.Enqueue(platform);

        // If we exceed the limit, destroy the oldest platform
        if (activePlatforms.Count > maxPlatforms)
        {
            GameObject oldest = activePlatforms.Dequeue();
            if (oldest != null) Destroy(oldest);
            else
                Debug.Log("oldest is null");
        }
    }
}

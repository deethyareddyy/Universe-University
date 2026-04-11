using UnityEngine;
using System.Collections.Generic;

public class PortraitManager : MonoBehaviour
{
    public static PortraitManager Instance;
    public List<Sprite> portraitPool = new List<Sprite>();

    void Awake()
    {
        // Standard Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        // Optional, keep this manager alive across all scenes
        DontDestroyOnLoad(gameObject);
    }
}

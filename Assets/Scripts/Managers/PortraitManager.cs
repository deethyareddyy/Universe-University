using UnityEngine;
using System.Collections.Generic;

public class PortraitManager : MonoBehaviour
{
    public static PortraitManager Instance;
    public List<Sprite> portraitPool = new List<Sprite>();
    public int current = 0; 

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
    public void Randoming()
    {
        int dum =  Random.Range(0, PortraitManager.Instance.portraitPool.Count);
        while (dum == current)
        {
            dum = Random.Range(0, PortraitManager.Instance.portraitPool.Count);
        }
        current = dum; 
    }
}

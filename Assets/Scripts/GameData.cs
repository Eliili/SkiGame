using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameData : MonoBehaviour
{

    public int completedRaces;

    private static GameData instance;

    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                // Look for an existing instance in the scene
                instance = FindObjectOfType<GameData>();

                // If no instance exists, create a new one
                if (instance == null)
                {
                    // Create a new GameObject to hold the GameData instance
                    GameObject singletonObject = new GameObject("GameData");
                    instance = singletonObject.AddComponent<GameData>();

                    // Make sure the GameObject persists between scenes
                    DontDestroyOnLoad(singletonObject);
                }
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            Destroy(gameObject);

        }
        else if (instance != this)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
    

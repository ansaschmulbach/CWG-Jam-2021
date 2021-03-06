using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void LoadMainMenu()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadDeathScene()
    {
        
    }
    
}

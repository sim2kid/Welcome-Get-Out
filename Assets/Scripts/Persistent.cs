using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Persistent : MonoBehaviour
{
    private static Persistent s_Instance = null;
    public bool NarratorIsNice;
    public string LastScene 
    {
        get;
        private set;
    }
    public string CurrentScene
    {
        get;
        private set;
    }
    public bool GameWasClosed;

    void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
            DontDestroyOnLoad(gameObject);

            Initilize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Persistent Get() 
    {
        return (Persistent)Object.FindObjectOfType(typeof(Persistent));
    }

    private void Initilize() 
    {
        NarratorIsNice = false;
        CurrentScene = "";
        LastScene = "";
        // Actually need to check for this!!
        GameWasClosed = false;
    }

    public void UpdateScene() 
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (CurrentScene != sceneName)
        {
            LastScene = CurrentScene;
            CurrentScene = sceneName;
        }
    }
}

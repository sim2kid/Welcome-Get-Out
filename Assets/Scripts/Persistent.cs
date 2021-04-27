using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Initilize() 
    {
        NarratorIsNice = false;
        CurrentScene = "";
        LastScene = "";
        // Actually need to check for this!!
        GameWasClosed = false;
    }

    public void UpdateScene(string sceneName) 
    {
        if (CurrentScene != sceneName)
        {
            LastScene = CurrentScene;
            CurrentScene = sceneName;
        }
    }
}

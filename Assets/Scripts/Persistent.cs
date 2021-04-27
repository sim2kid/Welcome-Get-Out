using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Persistent : MonoBehaviour
{
    private static Persistent s_Instance = null;
    public bool isOriginal = false;
    public bool NarratorIsNice;
    [SerializeField]
    private string m_lastScene;
    [SerializeField]
    private string m_currentScene;
    public string LastScene 
    {
        get { return m_lastScene; }
        private set { m_lastScene = value; }
    }
    public string CurrentScene
    {
        get { return m_currentScene; }
        private set { m_currentScene = value; }
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
        Object[] objs = Object.FindObjectsOfType(typeof(Persistent));
        foreach (Object ob in objs)
            if (((Persistent)ob).isOriginal) 
            {
                return (Persistent)ob;
            }
        Persistent newData = new GameObject().AddComponent<Persistent>();
        newData.name = "Data";
        newData.isOriginal = true;
        return newData;
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

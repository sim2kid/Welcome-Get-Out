using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    GameObject levels;

    Persistent data;

    private void Start()
    {
        data = Persistent.Get();
        data.UpdateScene();
        levels.SetActive(false);
    }

    public void ToggleLevels() 
    {
        levels.SetActive(!levels.activeSelf);
    }

    public void JumpToLevel(int level) 
    {
        if(level == -1)
            UnityEngine.SceneManagement.SceneManager.LoadScene($"Credits");
        else
            UnityEngine.SceneManagement.SceneManager.LoadScene($"Level-{level}");
    }
}

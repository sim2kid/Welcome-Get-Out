using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    GameObject levels;

    private void Start()
    {
        levels.SetActive(false);
    }

    public void ToggleLevels() 
    {
        levels.SetActive(!levels.activeSelf);
    }

    public void JumpToLevel(int level) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene($"Level-{level}");
    }
}

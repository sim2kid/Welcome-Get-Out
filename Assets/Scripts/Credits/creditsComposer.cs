using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Persistent))]
public class creditsComposer : MonoBehaviour
{
    [SerializeField]
    GameObject backButton;
    [SerializeField]
    GameObject mainScreenButton;
    [SerializeField]
    NarratorController narrator;
    [SerializeField]
    DialogueTree MeanCredits;
    [SerializeField]
    DialogueTree NiceCredits;
    [SerializeField]
    Animator CreditsAnimation;

    bool triggeredAnime;

    Persistent data;
    void Start()
    {
        triggeredAnime = false;
        data = GetComponent<Persistent>();
        data.UpdateScene();
        mainScreenButton.SetActive(false);
        if (data.LastScene == "Level-1" || data.LastScene == "Level-0")
            backButton.SetActive(true);
        else
            backButton.SetActive(false);
        if (data.NarratorIsNice)
        {
            narrator.NewNarration(NiceCredits, 0);
        }
        else 
        {
            narrator.NewNarration(MeanCredits, 0);
        }
    }

    private void Update()
    {
        if (!triggeredAnime && narrator.atIndex() == 6 && !data.NarratorIsNice) 
        {
            triggeredAnime = true;
            CreditsAnimation.SetTrigger("run");
        }
        if (!mainScreenButton.activeSelf && narrator.IsOver() && !narrator.IsTalking()) 
        {
            mainScreenButton.SetActive(true);
        }
    }

    public void BackButton() 
    {
        SceneManager.LoadScene(data.LastScene);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Level-1");
    }
}

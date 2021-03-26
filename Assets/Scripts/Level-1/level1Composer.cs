using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1Composer : MonoBehaviour
{
    [SerializeField]
    private DialogueTree curtainDialogue;
    [SerializeField]
    private NarratorController narrator;
    [SerializeField]
    private AudioController soundEffects;
    [SerializeField]
    private Animator CurtainAnimator;
    [SerializeField]
    private DialogueTree openSesameDialogue;
    [SerializeField]
    private DialogueTree menu;
    [SerializeField]
    private DialogueTree rat;
    [SerializeField]
    private Animator ratamation;
    [SerializeField]
    private GameObject exitButton;
    [SerializeField]
    private GameObject exitAlt;

    private int touchCount;
    public int treeCount;

    private void Start()
    {
        touchCount = 0;
        treeCount = 0;
    }

    private void Update()
    {
        if (narrator.IsOver()) 
        {
            switch (treeCount) 
            {
                case 1:
                    treeCount++;
                    CurtainAnimator.SetTrigger("Open");
                    narrator.NewNarration(menu, 0);
                    break;
                case 2:
                    treeCount++;
                    narrator.NewNarration(rat, 0);
                    ratamation.SetTrigger("RunRatRun");
                    break;
                case 3:
                    float next = exitButton.transform.position.x - ((exitButton.transform.position.x/1.1f) * Time.deltaTime);
                    exitButton.transform.position = new Vector3(next, exitButton.transform.position.y, exitButton.transform.position.z);
                    exitButton.GetComponent<MirrorAsset>().ForceMoveUpdate();
                    if (exitButton.transform.position.x <= 0.5 && -0.5 <= exitButton.transform.position.x) 
                    {
                        treeCount++;
                    }
                    break;
            }
                
        }
    }

    public void Exit() 
    {
        Application.Quit();
#if UNITY_EDITOR
        Debug.Log("You tried to exit the game, but Unity can't quit, so you get this neat little messege instead! Hi Friends!");
#endif
    }

    public void StartGame() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level-2");
    }

    public void Settings() 
    {
        //IDEK HOW TO DO THIS
        Debug.Log("Hey, Don't forget to add the Settings at some point!");
    }

    public void OpenCurtains() 
    {
        CurtainAnimator.SetTrigger("Open");
        narrator.NewNarration(openSesameDialogue, 0);
        treeCount++;
    }
    public void TouchCurtainDialogue() 
    {
        if (touchCount == 0) 
        {
            narrator.NewNarration(curtainDialogue, 0);
        }
        else 
        {
            narrator.Trigger();
        }
        touchCount++;
    }
}

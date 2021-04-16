using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CheckMark : MonoBehaviour
{
    private Animator anime;
    [SerializeField]
    public bool isTrue;
    void Start()
    {
        anime = GetComponent<Animator>();
        updateAnimator();
    }

    private void FixedUpdate()
    {
        updateAnimator();
    }

    public void SetState(bool TorF) 
    {
        isTrue = TorF;
        updateAnimator();
    }
    public void ToggleState()
    {
        SetState(!isTrue);
    }

    private void updateAnimator() 
    {
        anime.SetBool("True", isTrue);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ButtonAnimation : Intractable
{
    private Animator buttonAnimation;
    void Start()
    {
        buttonAnimation = GetComponent<Animator>();
    }

    public override void OnUnclick()
    {
        AnimeUp();
        base.OnUnclick();
    }
    public override void OnClick()
    {
        AnimeDown();
        base.OnClick();
    }
    public override void OnLeave(ClickType clickType)
    {
        if(clickType == ClickType.Hold)
            AnimeUp();
        base.OnLeave(clickType);
    }

    protected void AnimeUp() 
    {
        buttonAnimation.SetTrigger("Up");
    }
    protected void AnimeDown()
    {
        buttonAnimation.SetTrigger("Down");
    }
}

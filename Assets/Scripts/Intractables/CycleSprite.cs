﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CycleSprite : Intractable
{
    [SerializeField]
    private List<Sprite> spriteList = new List<Sprite>();
    [SerializeField]
    private int onSprite = 0;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = spriteList[onSprite];
    }

    public override void OnFullClick()
    {
        nextSprite();
        base.OnFullClick();
    }

    private void nextSprite() 
    {
        onSprite++;
        if (onSprite >= spriteList.Count || onSprite < 0) 
        {
            onSprite = 0;
        }
        sr.sprite = spriteList[onSprite];
    }
}

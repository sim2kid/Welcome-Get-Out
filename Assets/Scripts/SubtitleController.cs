using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(TextMeshPro))]
public class SubtitleController : MonoBehaviour
{
    Animator anime;
    TextMeshPro text;

    [SerializeField]
    bool visable;
    void Start()
    {
        anime = GetComponent<Animator>();
        text = GetComponent<TextMeshPro>();
        Show();
        text.text = "";
    }

    public void Show() 
    {
        visable = true;
        anime.SetBool("Visable", visable);
    }

    public void Hide() 
    {
        visable = false;
        anime.SetBool("Visable", visable);
    }

    public void SetText(string text) 
    {
        this.text.text = text;
    }
}

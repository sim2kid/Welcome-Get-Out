using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ProgressBar : MonoBehaviour
{
    SpriteRenderer renderer;
    [SerializeField] [Range(0f,1f)]
    private float progress;
    [SerializeField]
    [Range(1f, 100f)]
    private float scooch;

    private float feelLikeProgress;
    private float initalWidth;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.drawMode = SpriteDrawMode.Sliced;
        initalWidth = renderer.size.x;
    }

    private void updateBar() 
    {
        renderer.size = new Vector2(initalWidth * feelLikeProgress, renderer.size.y);
    }

    private void Update()
    {
        feelLikeProgress += (progress - feelLikeProgress) / scooch;
        updateBar();
    }

    public float GetProgress() 
    {
        return progress;
    }

    public void modifyProgress(float amount) {
        progress += amount;
        if (progress < 0)
            progress = 0;
        if (progress > 1)
            progress = 1;
    }
}

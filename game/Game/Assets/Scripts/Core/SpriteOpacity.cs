using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOpacity : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float stepOfPollution = 0.1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        makeTransparent();
    }

    public void makeTransparent()
    {
        changeTransparent(0f);
    }
    
    public void makeNonTransparent()
    {
        changeTransparent(1f);
    }

    public void changeTransparent(float newAlpha)
    {
        if (spriteRenderer != null)
        {
            Color newColor = spriteRenderer.color;
            newColor.a = newAlpha;
            spriteRenderer.color = newColor;
        }
    }

    public void plusTransparent()
    {
        if (spriteRenderer != null)
        {
            Color newColor = spriteRenderer.color;
            if ( newColor.a + stepOfPollution < 1f) newColor.a += stepOfPollution;
            else newColor.a = 1;
            spriteRenderer.color = newColor;
        }
    }
}

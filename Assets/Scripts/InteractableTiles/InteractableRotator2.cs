using System.Collections.Generic;
using UnityEngine;

public class InteractableRotator2 : InteractableTile
{
    public List<Sprite> Sprites;
    
    private int currentSpriteNumber = 0;
    private SpriteRenderer rotatedObjectSpriteRenderer;

    public override void Interact()
    {
        Rotate();
    }
    
    public void Rotate()
    {
        currentSpriteNumber++;

        if (currentSpriteNumber >= Sprites.Count)
        {
            currentSpriteNumber = 0;
        }

        ShowNextSprite();
    }

    private void ShowNextSprite()
    {
        rotatedObjectSpriteRenderer.sprite = Sprites[currentSpriteNumber];
    }
    
    public void Start()
    {
        rotatedObjectSpriteRenderer = GetComponent<SpriteRenderer>();
    }
}

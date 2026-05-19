using System.Collections.Generic;
using UnityEngine;

public class InteractableRotator2 : InteractableTile
{
    public AudioClip StatueTurn;
    
    public List<Sprite> Sprites;
    public bool IsSolved = false;
    
    private int currentSpriteNumber = 0;
    private SpriteRenderer rotatedObjectSpriteRenderer;

    public override void Interact()
    {
        if (!IsSolved)
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
        
        AudioManager.Instance.PlayVariableSFX(StatueTurn);
    }
    
    public void Start()
    {
        rotatedObjectSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Lock()
    {
        IsSolved = true;
    }
    
    public int GetCurrentSpriteIndex() 
    {
        return currentSpriteNumber;
    }
}

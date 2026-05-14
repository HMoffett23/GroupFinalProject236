using System;
using DG.Tweening;
using UnityEngine;

public class InteractableItem : InteractableTile
{
    public Inventory Inventory;
    private SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Inventory = FindFirstObjectByType<Inventory>();
    }

    private void Start()
    {
        AnimateItem();
    }

    public void AnimateItem()
    {
        transform.DOScale(endValue: 1f + 0.3f, duration: 1f / 0.5f)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    public override void Interact()
    {
        bool itemAdded = Inventory.AddItem(spriteRenderer.sprite);
            
        if (itemAdded)
        {
            Destroy(gameObject);
        }
    }
}

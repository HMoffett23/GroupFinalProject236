using UnityEngine;

public class InteractableRotator1 : InteractableTile
{
    public SpriteRenderer rotatedObjectSpriteRenderer;
   
    public override void Interact()
    {
        rotatedObjectSpriteRenderer.transform.Rotate(Vector3.forward, 90);
    }
}

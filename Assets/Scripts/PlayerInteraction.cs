using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private TileType currentTileType;
    
    private InteractableButton currentButtonScript;
    private InteractableText currentTextScript;
   
    private void OnTriggerStay2D(Collider2D other)
    {
        if (InteractableTile.IsInteracting)
        {
            CheckInteractableTileType(other);
            Interact();
        }
    }

    private void CheckInteractableTileType(Collider2D other)
    {
        if (other.CompareTag("Button"))
        {
            currentTileType = TileType.Button;
            currentButtonScript = other.GetComponent<InteractableButton>();
        }
        else if (other.CompareTag("Door"))
        {
            currentTileType = TileType.Door;
        }
        else if (other.CompareTag("Statue"))
        {
            currentTileType = TileType.Statue;
        }
        else if (other.CompareTag("Text"))
        {
            currentTileType = TileType.Text;
            currentTextScript = other.GetComponent<InteractableText>();
        }
    }

    public enum TileType
    {
        Button,
        Door,
        Statue,
        Text
    }

    private void Interact()
    {
        switch (currentTileType)
        {
            case TileType.Button:
                currentButtonScript.OpenDoor();
                break;
            /*case TileType.Door:
                InteractableDoor.OpenDoor();
                break;
            case TileType.Statue:
                InteractableStatue.Rotate();
                break;
            case TileType.Text:
                InteractableText.DisplayText();*/
        }
    }
}

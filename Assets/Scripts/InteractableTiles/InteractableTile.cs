using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class InteractableTile : MonoBehaviour
{
    private bool isPlayerInRange = false;
    
    void Update()
    {
        if (isPlayerInRange && KeyboardInput.IsInteractKeyPressed())
        {
            Interact();
        }
    }

    public virtual void Interact()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = false;
        }
    }
}

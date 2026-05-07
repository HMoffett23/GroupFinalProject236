using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class InteractableTile : MonoBehaviour
{
    public static bool IsInteracting = false;
    
    private bool isPlayerInRange = false;
    private Coroutine countdownCoroutine;

    void Update()
    {
        if (isPlayerInRange && KeyboardInput.IsInteractKeyPressed())
        {
            countdownCoroutine = StartCoroutine(InteractionCoroutine());
        }
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

    private IEnumerator InteractionCoroutine()
    {
        IsInteracting = true;
        
        float interactTime = GameParameters.InteractTimeInSeconds;
        
        yield return new WaitForSeconds(interactTime);
        IsInteracting = false;
    }
}

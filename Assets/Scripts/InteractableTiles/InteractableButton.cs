using UnityEngine;

public class InteractableButton : InteractableTile
{
    public GameObject door;
    
    public override void Interact()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        door.SetActive(false);
    }
}

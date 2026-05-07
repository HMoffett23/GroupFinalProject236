using UnityEngine;

public class InteractableButton : InteractableTile
{
    public GameObject door;
    
    public void OpenDoor()
    {
        door.SetActive(false);
    }
}

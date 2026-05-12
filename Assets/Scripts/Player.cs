using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    public Inventory Inventory;
    public TrapPlacer TrapPlacer;
    private List<string> pickableItems = new List<string>
    {
        "Bone", "Beer", "StoneRed", "StoneBlue", "StoneYellow", "StoneGreen"
    };
    
    public void HandleItemPickup(Collider2D other)
    {
        bool itemAdded = Inventory.AddItem(other.GetComponent<SpriteRenderer>().sprite);
        if (itemAdded)
        {
            Destroy(other.gameObject);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (pickableItems.Contains(other.tag))
        {
            HandleItemPickup(other);
        }
        else if (other.tag == "Trap")
        {
            Destroy(other.gameObject);
            TrapPlacer.Placer();
        }
    }
}

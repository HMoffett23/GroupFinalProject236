using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    public Inventory Inventory;
    
    public TrapPlacer TrapPlacer;

    public void Move()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bone")
        {
            Destroy(other.gameObject);
            Inventory.AddItem(other.GetComponent<SpriteRenderer>().sprite);
        }
        else if (other.tag == "Beer")
        {
            Destroy(other.gameObject);
            Inventory.AddItem(other.GetComponent<SpriteRenderer>().sprite);
        }
        else if (other.tag == "Trap")
        {
            Destroy(other.gameObject);
            TrapPlacer.Placer();
        }
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Spikes")
        {
            print("ouch!");
            Destroy(other.gameObject);
            
            // reduce HP
        }
    }
}

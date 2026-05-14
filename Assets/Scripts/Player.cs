using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    public TrapPlacer TrapPlacer;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Trap")
        {
            Destroy(other.gameObject);
            TrapPlacer.Placer();
        }
    }
}

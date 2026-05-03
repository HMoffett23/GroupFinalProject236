using UnityEngine;

public class Spike : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Treeline")
        {
            Destroy(gameObject);
        }
    }
}

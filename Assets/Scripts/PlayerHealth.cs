using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public TMP_Text playerHealthText;
    private SpriteRenderer playerSpriteRenderer;
    
    public float maxHealth = 3;
    public float currentHealth;

    public void Awake()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void UpdateHealthWhenSpikeHits()
    {
        currentHealth = currentHealth - 1;
        if (currentHealth <= 0)
        {
            currentHealth = 3;
            Respawn();
        }
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Spikes")
        {
            UpdateHealthWhenSpikeHits();
            ChangeHealthInUI();
            Destroy(other.gameObject);
        }
    }
    public void ChangeHealthInUI()
         {
             playerHealthText.text = "HP: " + currentHealth + "/" + maxHealth;
         }

    public void Respawn()
    { 
        playerSpriteRenderer.transform.position = new Vector3(-6,2,0);
    }
}

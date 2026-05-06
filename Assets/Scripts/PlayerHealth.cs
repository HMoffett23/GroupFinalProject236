using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public TMP_Text playerHealthText;
    
    public float maxHealth = 3;
    public float currentHealth;

    public void UpdateHealthWhenSpikeHits()
    {
        currentHealth = currentHealth - 1;
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
}

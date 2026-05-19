using Unity.VisualScripting;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    public AudioManager.Puzzles PuzzleToSwitchTo;
    
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        
        if (audioManager == null)
        {
            Debug.LogError("MusicSwitcherZone: No MusicManager found in the scene!");
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && audioManager != null)
        {
            audioManager.AssignMusic(PuzzleToSwitchTo);
        }
    }
}

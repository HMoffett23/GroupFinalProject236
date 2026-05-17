using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } 

    [Header("Ambient & Music Sources")]
    public AudioSource backgroundMusic; 
    public AudioSource waterSFX; 
    public AudioSource jungleSFX; 

    [Header("Audio Clips")]
    public AudioClip MenuMusic; 
    public AudioClip JungleSounds; 
    public AudioClip WaterSounds; 
    
    public Puzzles currentPuzzle;

    public enum Puzzles
    {
        MainMenu,
        Stones, 
        Statues, 
        Maze,
        Idol
    }
    
    private Dictionary<string, AudioSource> sfxPool = new Dictionary<string, AudioSource>();

    private void Awake() 
    { 
        if (Instance == null) 
        { 
            Instance = this; 
        } 
        else 
        { 
            Destroy(gameObject); 
        } 
    } 

    private void Start() 
    { 
        AssignMusic(); 
        PlayJungleSounds(JungleSounds); 
        PlayWaterSounds(WaterSounds); 
    } 
    
    public void PlayVariableSFX(AudioClip clip) 
    { 
        if (clip == null) return;
        
        if (!sfxPool.ContainsKey(clip.name))
        {
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            
            newSource.playOnAwake = false;
            newSource.spatialBlend = 0f;
            
            sfxPool.Add(clip.name, newSource);
        }

        AudioSource dedicatedSource = sfxPool[clip.name];
        
        dedicatedSource.clip = clip;
        dedicatedSource.volume = .25f; 
        dedicatedSource.Play(); 
    } 

    private void PlayWaterSounds(AudioClip clip) 
    { 
        if (clip == null) return;
        waterSFX.clip = clip; 
        waterSFX.Play(); 
    } 

    private void PlayJungleSounds(AudioClip clip) 
    { 
        if (clip == null) return;
        jungleSFX.clip = clip; 
        jungleSFX.Play(); 
    } 

    private void AssignMusic() 
    { 
        switch (currentPuzzle) 
        { 
            case Puzzles.MainMenu: 
                PlayBackgroundMusic(MenuMusic); 
                break; 
            /* 
            case Puzzles.Stones: 
                PlayBackgroundMusic(StonesMusic); 
                break; 
            case Puzzles.Statues: 
                PlayBackgroundMusic(StatuesMusic); 
                break; 
            case Puzzles.Maze: 
                PlayBackgroundMusic(MazeMusic); 
                break; 
            */ 
        } 
    } 

    private void PlayBackgroundMusic(AudioClip clip) 
    { 
        if (clip == null) return;
        backgroundMusic.clip = clip; 
        backgroundMusic.Play(); 
    } 

    /*
    // Left commented out as requested, but updated to route through the new isolated pooling system 
    // to fix future volume variance issues.
    public void PlayCollectSFX() { PlayVariableSFX(collect); } 
    public void PlayWinSFX() { PlayVariableSFX(win); backgroundMusic.Stop(); } 
    public void PlayLoseSFX() { PlayVariableSFX(lose); backgroundMusic.Stop(); } 
    public void PlayUIClick() { PlayVariableSFX(uiClick); }
    */
}
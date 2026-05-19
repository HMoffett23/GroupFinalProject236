using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } 
    
    [Header("Crossfade Settings")]
    public float fadeDuration = GameParameters.FadeDurationInSeconds;
    private AudioSource activeSource;
    private Coroutine crossfadeCoroutine;

    [Header("Ambient & Music Sources")]
    public AudioSource musicSourceA;
    public AudioSource musicSourceB; 
    public AudioSource waterSFX; 
    public AudioSource jungleSFX; 

    [Header("Music Audio Clips")]
    public AudioClip MenuMusic;
    public AudioClip StonesMusic;
    public AudioClip StatuesMusic;
    
    [Header("Ambient Audio Clips")]
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
            
            activeSource = musicSourceA; 
        } 
        else 
        { 
            Destroy(gameObject); 
        } 
    } 
    
    private void Start() 
    { 
        currentPuzzle = Puzzles.Idol;
        
        AssignMusic(Puzzles.MainMenu); 
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
        dedicatedSource.volume = .45f; 
        dedicatedSource.pitch = 1f;
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

    public void AssignMusic(Puzzles newPuzzle)
    {
        if (currentPuzzle == newPuzzle)
            return;
        
        currentPuzzle = newPuzzle;
        
        switch (currentPuzzle) 
        { 
            case Puzzles.MainMenu: 
                CrossfadeToNewMusic(MenuMusic); 
                break; 
            case Puzzles.Stones: 
                CrossfadeToNewMusic(StonesMusic); 
                break; 
            case Puzzles.Statues: 
                CrossfadeToNewMusic(StatuesMusic); 
                break; 
            /*
            case Puzzles.Maze: 
                CrossfadeToNewMusic(MazeMusic); 
                break; 
            */ 
        } 
    }

    private void CrossfadeToNewMusic(AudioClip newClip)
    {
        if (newClip == null) return;
        
        if (crossfadeCoroutine != null)
        {
            StopCoroutine(crossfadeCoroutine);
        }
        
        AudioSource newSource = (activeSource == musicSourceA) ? musicSourceB : musicSourceA;
        
        crossfadeCoroutine = StartCoroutine(CrossfadeSequence(activeSource, newSource, newClip));
        
        activeSource = newSource;
    }

    private IEnumerator CrossfadeSequence(AudioSource fadingOut, AudioSource fadingIn, AudioClip newClip)
    {
        fadingIn.clip = newClip;
        fadingIn.volume = 0f;
        fadingIn.Play();

        float startVolumeOut = fadingOut.volume;
        float targetVolumeIn = 1.0f;
        float timer = 0f;
        
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / fadeDuration;

            fadingOut.volume = Mathf.Lerp(startVolumeOut, 0f, normalizedTime);
            fadingIn.volume = Mathf.Lerp(0f, targetVolumeIn, normalizedTime);

            yield return null;
        }
        
        fadingOut.volume = 0f;
        fadingOut.Stop();
        fadingIn.volume = targetVolumeIn;
    }

    /*
    public void PlayCollectSFX() { PlayVariableSFX(collect); } 
    public void PlayWinSFX() { PlayVariableSFX(win); backgroundMusic.Stop(); } 
    public void PlayLoseSFX() { PlayVariableSFX(lose); backgroundMusic.Stop(); } 
    public void PlayUIClick() { PlayVariableSFX(uiClick); }
    */
}
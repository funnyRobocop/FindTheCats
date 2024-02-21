using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
  public static SoundManager Instance { get; private set; }
  public AudioSource audioSource;
  public AudioClip[] catsSounds;
private void Awake() 
{ 
    // If there is an instance, and it's not me, delete myself.
    
    if (Instance != null && Instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        Instance = this; 
    } 
}

private void PlayShot(AudioClip clip)
{
    audioSource.PlayOneShot(clip);
}

public void PlayRandomSounds()
{
    PlayShot(catsSounds[Random.Range(0,catsSounds.Length)]);
}
}

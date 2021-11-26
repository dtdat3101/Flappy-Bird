using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource audioSource;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }
    private void OnValidate()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }
    public void OnPlaySound(SoundType soundType)
    {
        var audio = Resources.Load<AudioClip>(path:$"Sound/{soundType.ToString()}");
        audioSource.PlayOneShot(audio);
    }
}

public enum SoundType
{
    NONE=0,
    CLICK = 1,
    GAMEOVER = 2,
}

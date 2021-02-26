using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject bgSound;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        var bgSoundOne = GameObject.Find("Big in Japan");
        if (bgSoundOne == null)
        {
            bgSoundOne = Instantiate(bgSound);
            DontDestroyOnLoad(bgSoundOne);
        }
    }
    
    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }

}

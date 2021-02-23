using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMagnet : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void ApplyEffect()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball bal in balls)
        {
            bal.MagnetActivate();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            ApplyEffect();
            Destroy(gameObject);
        }
        
    }
    
}

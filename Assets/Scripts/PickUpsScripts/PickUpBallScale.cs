using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBallScale : MonoBehaviour
{
    public float ballScale;
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
            bal.BallScale(ballScale);
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

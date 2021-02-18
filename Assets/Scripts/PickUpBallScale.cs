using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBallScale : MonoBehaviour
{
    public Ball balls;
    public float ballScale;

    public AudioSource audioSource;
    void ApplyEffect()
    {
        balls = FindObjectOfType<Ball>();
        balls.BallScale(ballScale);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.Play();
        if (collision.gameObject.CompareTag("Player"))
        {
            
            ApplyEffect();
            Destroy(gameObject);
        }
    }
}

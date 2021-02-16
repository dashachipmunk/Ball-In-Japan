using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMagnet : MonoBehaviour
{
    void ApplyEffect()
    {
        Ball balls = FindObjectOfType<Ball>();
        balls.MagnetActivate();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyEffect();
            Destroy(gameObject);
        }
    }
}

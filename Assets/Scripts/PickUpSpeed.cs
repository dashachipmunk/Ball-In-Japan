using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpeed : MonoBehaviour
{
    public float speedCoeff;
    void ApplyEffect()
    {
        Ball balls = FindObjectOfType<Ball>();
        balls.MultiplySpeed(speedCoeff);
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

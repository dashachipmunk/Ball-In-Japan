using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDuplicateBall : MonoBehaviour
{
    void ApplyEffect()
    {
        Ball balls = FindObjectOfType<Ball>();
        balls.DuplicateBall();        
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

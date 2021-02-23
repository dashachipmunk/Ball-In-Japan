using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Obsolete]
public class PickUpScore : MonoBehaviour
{
    public int pickUpPoints;
    
    void ApplyEffect()
    {
        GameManager gM = FindObjectOfType<GameManager>();
        gM.AddScore(pickUpPoints);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PickUpScore : MonoBehaviour
{
    public int pickUpPoints;
    SoundManager sM;
    public AudioClip pickup;
    private void Awake()
    {
        sM = FindObjectOfType<SoundManager>();
    }
    void ApplyEffect()
    {
        GameManager gM = FindObjectOfType<GameManager>();
        gM.AddScore(pickUpPoints);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sM.PlaySound(pickup);
            ApplyEffect();
            Destroy(gameObject);
        }
    }
}

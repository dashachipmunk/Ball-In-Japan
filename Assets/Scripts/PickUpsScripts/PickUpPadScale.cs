using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPadScale : MonoBehaviour
{
    public float newSize;
    SoundManager sM;
    public AudioClip pickup;
    private void Awake()
    {
        sM = FindObjectOfType<SoundManager>();
    }
    void ApplyEffect()
    {
        Player pad  = FindObjectOfType<Player>();
        pad.PadScale(newSize);
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

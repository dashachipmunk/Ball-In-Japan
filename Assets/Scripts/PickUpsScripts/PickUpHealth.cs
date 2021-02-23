using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealth : MonoBehaviour
{
    public int addHeart;
    void ApplyEffect()
    {
        HeartsBar hearts = FindObjectOfType<HeartsBar>();
        hearts.AddRemoveHeart(addHeart);
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

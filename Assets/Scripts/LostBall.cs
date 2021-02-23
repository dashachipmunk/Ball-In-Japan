using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostBall : MonoBehaviour
{
    public HeartsBar health;
    public Ball ball;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        health = FindObjectOfType<HeartsBar>();
        ball = FindObjectOfType<Ball>();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            StartCoroutine(Wait(1.3f));
            health.MinusHeart();
            audioSource.Play();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
    public IEnumerator Wait(float delayInSecs)
    {
        yield return new WaitForSeconds(delayInSecs);
        ball.Restart();
    }
}

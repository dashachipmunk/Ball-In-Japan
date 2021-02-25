using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostBall : MonoBehaviour
{
    public HeartsBar health;
    Ball[] balls;
    Ball ball;
    public int ballsLength;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        health = FindObjectOfType<HeartsBar>();
    }

    private void Update()
    {
        balls = FindObjectsOfType<Ball>();
        ballsLength = balls.Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            ballsLength--;
            if (ballsLength == 0)
            {
                Invoke("BallRestart", 1.3f);
                health.MinusHeart();
                StartCoroutine(Wait(1f));
            }
            audioSource.Play();
            if (ballsLength > 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
    public void BallRestart()
    {
        ball = FindObjectOfType<Ball>();
        ball.Restart();
    }
    public IEnumerator Wait(float delayInSecs)
    {
        yield return new WaitForSeconds(delayInSecs);
        Destroy(gameObject.GetComponent<Ball>());
    }
}

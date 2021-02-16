using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostBall : MonoBehaviour
{
    public Ball ball;
    public GameManager gM;
    public HeartsBar health;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gM = FindObjectOfType<GameManager>();
        health = FindObjectOfType<HeartsBar>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            ball.Restart();
            health.MinusHeart();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}

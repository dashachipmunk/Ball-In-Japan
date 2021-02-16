using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;

    public float initialSpeed;
    public float currentSpeed;

    public float yPosition;
    public float xDelta;
    public float yDelta;

    bool isStarted;
    bool isMagnetActive;

    public Player pad;

    public TrailRenderer trailRenderer;
    private void Start()
    {
        currentSpeed = initialSpeed;
        yPosition = transform.position.y;
        trailRenderer = GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        if (isStarted)
        {
            rb.velocity = rb.velocity.normalized * currentSpeed;
        }
        else
        {
            transform.position = new Vector3(pad.transform.position.x + xDelta, yPosition, 0);
            if (Input.GetMouseButtonDown(0))
            {
                StartBall();
            }
        }
    }
    public void MultiplySpeed(float speedCoeff)
    {
        currentSpeed *= speedCoeff;
    }
    public void MagnetActivate()
    {
        isMagnetActive = true;
    }
    public void DuplicateBall()
    {
        Ball originalBall = this;
        Ball newBall = Instantiate(originalBall);
        newBall.currentSpeed = currentSpeed;
        newBall.StartBall();
        if (isMagnetActive)
        {
            newBall.MagnetActivate();
        }
    }
    public void BallScale(float ballScale)
    {
        transform.localScale = new Vector3(ballScale, ballScale, ballScale);
        //yDelta = pad.transform.position.y - yPosition;
        //transform.position = new Vector3(pad.transform.position.x + xDelta, yPosition + yDelta, 0);
        //trailRenderer.startWidth = 0.25f;
    }
    
    void StartBall()
    {
        float randomX = Random.Range(0, 0);
        Vector2 direction = new Vector2(randomX, 1);
        Vector2 force = direction.normalized * currentSpeed;
        rb.velocity = force;
        isStarted = true;
    }
    public void Restart()
    {
        currentSpeed = initialSpeed;
        isMagnetActive = false;
        transform.localScale = new Vector3(1f, 1f, 1f);
        isStarted = false;
        transform.position = new Vector3(pad.transform.position.x + xDelta, yPosition, 0);
        rb.velocity = rb.velocity.normalized * currentSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isMagnetActive && collision.gameObject.CompareTag("Player"))
        {
            xDelta = transform.position.x - pad.transform.position.x;
            yPosition = transform.position.y;
            isStarted = false;
            transform.position = new Vector3(pad.transform.position.x + xDelta, yPosition, 0);
            rb.velocity = rb.velocity.normalized * currentSpeed;
        }
    }
}

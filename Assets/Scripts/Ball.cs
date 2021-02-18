using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [Header("Ball's characteristics")]
    public Rigidbody2D rb;
    public float initialSpeed;
    public float currentSpeed;
    public float ballSize;
    public PickUpSpeed bSpeed;
    public PickUpBallScale bScale;
    [Header("Ball's position")]
    public float yPosition;
    public float xDelta;
    public float yDelta;
    bool isStarted;
    bool isMagnetActive;
    [Header("Explode")]
    public float explodeRadius;
    public bool isExplosive;
    public GameObject explodeEffect;
    [Header("Pad")]
    public Player pad;
    public TrailRenderer trailRenderer;
    [Header("Sounds")]
    AudioSource audioSource;
    public AudioClip explodeSoundBall;
    public AudioClip hitBall;

    bool isFaster;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        ballSize = 1f;
        currentSpeed = initialSpeed;
        yPosition = transform.position.y;
        trailRenderer = GetComponent<TrailRenderer>();
        isExplosive = false;
        
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
    public void ActivateExplode()
    {
        isExplosive = true;
        explodeEffect.SetActive(true);
        print(isExplosive);
        audioSource.clip = explodeSoundBall;
    }
    public void MultiplySpeed(float speedCoeff)
    {
        currentSpeed *= speedCoeff;
        isFaster = true;
    }
    public void MagnetActivate()
    {
        isMagnetActive = true;
    }
    public void BallScale(float ballScale)
    {
        ballSize = ballScale;
        transform.localScale = new Vector3(ballSize, ballSize, ballSize);
    }
    public void DuplicateBall()
    {
        Ball originalBall = this;
        Ball newBall = Instantiate(originalBall);
        if (isFaster)
        {
            newBall.currentSpeed = currentSpeed;
        }
       
        newBall.StartBall();
        if (isExplosive)
        {
            newBall.ActivateExplode();
        }
        //if (ballSize != 1f)
        //{
        //    newBall.BallScale(bScale.ballScale);
        //}
        
        if (isMagnetActive)
        {
            newBall.MagnetActivate();
        }
    }
    void StartBall()
    {
        float randomX = Random.Range(0, 0);
        Vector2 direction = new Vector2(randomX, 1);
        Vector2 force = direction.normalized * currentSpeed;
        rb.velocity = force;
        isStarted = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }
    public void Restart()
    {
        currentSpeed = initialSpeed;
        isMagnetActive = false;
        ballSize = 1f;
        transform.localScale = new Vector3(ballSize, ballSize, ballSize);
        isStarted = false;
        transform.position = new Vector3(pad.transform.position.x + xDelta, yPosition, 0);
        rb.velocity = rb.velocity.normalized * currentSpeed;
    }
    void Explode()
    {
        int layerMask = LayerMask.GetMask("Block");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explodeRadius, layerMask);
        foreach (Collider2D col in colliders)
        {
            Blocks block = col.GetComponent<Blocks>();
            if (block == null)
            {
                Destroy(gameObject);
            }
            else
            {
                block.DestroyBlock();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
        if (isMagnetActive && collision.gameObject.CompareTag("Player"))
        {
            xDelta = transform.position.x - pad.transform.position.x;
            float newYPosition = transform.position.y;
            isStarted = false;
            rb.velocity = Vector2.zero;
            transform.position = new Vector3(pad.transform.position.x + xDelta, newYPosition, 0);
            
        }
        if (isExplosive && collision.gameObject.CompareTag("block"))
        {
            Explode();
        }
    }
}

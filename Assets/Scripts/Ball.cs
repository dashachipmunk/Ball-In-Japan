using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 force;
    public float speed;
    bool isStarted;
    public Player pad;
    private void Start()
    {
        force = new Vector2(Random.Range(1, 5), Random.Range(1, 2));
    }
    private void Update()
    {
        if (isStarted)
        {

        }
        else
        {
            transform.position = new Vector3(pad.transform.position.x, pad.transform.position.y + 1, 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
        if (transform.position.y <= -5f)
        {
            SceneManager.LoadScene("Game");
        }
    }
    void StartBall()
    {
        rb.AddForce(force * speed);
        isStarted = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Text score;
    public int count;

    void Start()
    {
        count = 0;
    }
    private void Update()
    {
        score.text = "Score: " + count;
        if (transform.position.y <= -5f)
        {
            PlayerPrefs.SetInt("Score", count);
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            count++;
        }
    }


}

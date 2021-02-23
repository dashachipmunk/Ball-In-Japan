using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsBar : MonoBehaviour
{
    [Header("Hearts images")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("Lives")]
    public int health;
    public int healthNumber;

    [Header("Ball")]
    public Ball ball;

    [Header("Game Over")]
    public GameObject gameOverPanel;
    public GameManager score;
    public Text totalScore;
    public bool isDead;
    private void Start()
    {
        HeartsStart();
    }

    public void MinusHeart()
    {
        health--;
        for (int i = 0; i < healthNumber; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < healthNumber)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        GameOver();
    }
    public void AddRemoveHeart(int addHeart)
    {
        if (addHeart > 0)
        {
            if (health < healthNumber)
            {
                hearts[healthNumber - 1].sprite = fullHeart;
                health++;
            }
            else if (health == healthNumber)
            {
                healthNumber++;
                hearts[healthNumber - 1].enabled = true;
                health++;
            }
        }
        else
        {
            MinusHeart();
        }
    }
    public void HeartsStart()
    {
        for (int j = 0; j < hearts.Length; j++)
        {
            hearts[j].enabled = false;
        }
        for (int k = 0; k < healthNumber; k++)
        {
            hearts[k].enabled = true;
        }
    }

    public void GameOver()
    {
        if (health <= 0)
        {
            isDead = true;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            totalScore.text = "Total score: " + score.score.ToString();
            
        }
    }
}

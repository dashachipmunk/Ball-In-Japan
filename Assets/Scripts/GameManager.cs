using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int score;

    public bool isPaused;
    public GameObject pausePanel;
    private void Awake()
    {
        
        GameManager[] gameManagers = FindObjectsOfType<GameManager>();
        for (int i = 0; i < gameManagers.Length; i++)
        {
            if (gameManagers[i].gameObject != gameObject)
            {
                Destroy(gameObject);
                break;
            }
        }
    }
   
    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        DontDestroyOnLoad(gameObject);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                pausePanel.active = false;
                Time.timeScale = 1f;
                isPaused = false;
            }
            else
            {
                pausePanel.active = true;
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
    }
    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score.ToString();
    }
}

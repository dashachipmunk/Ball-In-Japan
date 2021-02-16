using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameManager score;
    public Text totalScore;

    void Start()
    {
        score.score = PlayerPrefs.GetInt("Score", score.score);
        totalScore.text = "Total score: " + score.score.ToString();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Ball score;
    public Text totalScore;

    void Start()
    {
        score.count = PlayerPrefs.GetInt("Score", score.count);

        totalScore.text = "Total score: " + score.count.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameManager score;
    public Text totalScore;
    public Text bestScore;
    private void Awake()
    {
        //bestScore.text = "Best score: " + score.bestResult.ToString();
    }
    void Start()
    {
        score = FindObjectOfType<GameManager>();
        totalScore.text = "Total score: " + score.score.ToString();
       bestScore.text = "Best score: " + score.bestResult.ToString();
    }
    private void Update()
    {


    }

}

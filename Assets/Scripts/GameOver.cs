using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text totalScore;
    public Text bestScore;
    GameManager gm;
    HeartsBar hearts;
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        hearts = FindObjectOfType<HeartsBar>();
    }
    void Start()
    {
        totalScore.text = "Total score: " + gm.score.ToString();
        bestScore.text = "Best score: " + gm.bestResult.ToString();
        hearts.gameObject.SetActive(false);
        gm.scoreText.enabled = false;
    }

}

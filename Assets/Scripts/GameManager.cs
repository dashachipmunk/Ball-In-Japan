using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text score;
    public int scoreGame;

    private void Start()
    {
        PlayerPrefs.SetInt("Score", scoreGame);
    }
    private void Update()
    {
        score.text = "Score: " + scoreGame.ToString();
         
    }
}

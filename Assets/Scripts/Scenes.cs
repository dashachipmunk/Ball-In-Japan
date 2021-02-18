using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public Ball ballRestart;
    public HeartsBar heartRestart;
    public GameManager padRestart;

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);

    }
    public void RestartScene(string restartScene)
    {
        SceneManager.LoadScene(restartScene);
        //ballRestart.Restart();
        //heartRestart.isDead = false;
        //padRestart.isPaused = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}


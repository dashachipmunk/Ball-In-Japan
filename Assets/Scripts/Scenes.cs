using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public Ball ballRestart;
    public HeartsBar heartRestart;
    public GameManager gM;

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void RestartScene(string restartScene)
    {
        gM.RestartGM();
        heartRestart.HeartsStart();
        SceneManager.LoadScene(restartScene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    GameManager gM;
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void RestartScene(string restartScene)
    {
        
        SceneManager.LoadScene(restartScene);
        DestroyImmediate(gM.gameObject);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}


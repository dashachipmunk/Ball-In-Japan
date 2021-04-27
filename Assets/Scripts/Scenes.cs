using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    SoundManager sm;
    private void Start()
    {
        sm = FindObjectOfType<SoundManager>();
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
        if (scene == "Main")
        {
            print("hi");
        }
    }
    public void RestartScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}


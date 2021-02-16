using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public int blocksCount;
    public GameManager score;
    //private void Start()
    //{
    //    blocksCount = 0;
    //}

    public void BlockCreated()
    {
        blocksCount++;
    }

    public void BlockDestroyed()
    {
        blocksCount--;
        if (blocksCount <= 0)
        {
            //УРОВЕНЬ ПРОЙДЕН
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public int blocksCount;
    GameManager gm;
    HeartsBar heartsBar;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        heartsBar = FindObjectOfType<HeartsBar>();

    }
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
            //PlayerPrefs.SetInt("CurrentScore", gm.score);
            //PlayerPrefs.SetInt("Hearts", heartsBar.health);
            StartCoroutine(Wait(0.5f));
        }
    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Blocks : MonoBehaviour
{
    public int lifeBlock;
    private GameManager gM;

    //public Sprite blockImage;
    //public BlocksSO blocks;
    private void Start()
    {
        //blockImage = blocks.block;
        gM = FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        lifeBlock--;
        //if (lifeBlock > 0)
        //{
        //    blockImage = blocks.nextBlock[0];
        //}
        if (lifeBlock <= 0)
        {
            gM.scoreGame++;
            Destroy(gameObject);
        }
    }
}


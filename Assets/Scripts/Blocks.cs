using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Blocks : MonoBehaviour
{
    [Tooltip("Очки за блок")]
    public int points;
    public GameManager gamemanager;
    public LevelChanger lc;

    [Tooltip("Жизнь блока")]
    public int lifeBlock;
    public bool invisible;
    public SpriteRenderer sRender;
    [Tooltip("Пикапы и эффекты")]
    public GameObject particlePrefab;
    public PickUpChance pickUpChance;

    private void Start()
    {
        //indexArray = Random.Range(0, pickUpPrefab.Length - 1);
        gamemanager = FindObjectOfType<GameManager>();
        //pickUpChance = FindObjectOfType<PickUpChance>();

        lc = FindObjectOfType<LevelChanger>();
        lc.BlockCreated();
        if (invisible)
        {
            sRender = GetComponent<SpriteRenderer>();
            sRender.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invisible)
        {
            sRender.enabled = true;
            invisible = false;
            return;
        }
        lifeBlock--;
        if (lifeBlock <= 0)
        {
            DestroyBlock();
        }
    }
    public void DestroyBlock()
    {
        lc.BlockDestroyed();
        gamemanager.AddScore(points);
        Destroy(gameObject);
        Instantiate(particlePrefab, transform.position, Quaternion.identity);
        pickUpChance.CalculateChance();
        //Instantiate(pickUpChance.PickUpList[pickUpChance.indexPickUp].pickUp, transform.position, Quaternion.identity);
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Blocks : MonoBehaviour
{
    [Header("Block's points")]
    public int points;
    public GameManager gamemanager;
    public LevelChanger lc;
    [Header("Block's lives")]
    public int lifeBlock;
    public bool invisible;
    [Header("Block's sprites")]
    public Sprite[] blockDamaged;
    public SpriteRenderer sRender;
    [Header("Pick-ups and effects")]
    public GameObject particlePrefab;
    public GameObject[] pickUps;

    [Header("Sounds")]
    AudioSource audioSourceBlocks;
    public AudioClip soundDestroy;
    public AudioClip soundHit;
    SoundManager soundManager;
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    private void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        sRender = GetComponent<SpriteRenderer>();
        lc = FindObjectOfType<LevelChanger>();
        lc.BlockCreated();
        if (invisible)
        {
            sRender.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        soundManager.PlaySound(soundHit);
        if (invisible)
        {
            sRender.enabled = true;
            invisible = false;
            return;
        }
        lifeBlock--;
        for (int i = lifeBlock; i > 0; i--)
        {
            if (lifeBlock == i)
            {
                sRender.sprite = blockDamaged[i - 1];
            }
        }
        
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
        PickUpChance();
    }
    public void PickUpChance()
    {
        int randomValue = Random.Range(0, 40);
        Debug.Log("Random value " + randomValue);
        for (int i = 0; i < pickUps.Length; i++)
        {
            if (randomValue == i)
            {
                Instantiate(pickUps[i], transform.position, Quaternion.identity);
            }
            
        }
    }
}


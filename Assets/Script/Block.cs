using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config para
    public AudioClip BreakSound;
    [SerializeField] GameObject blockSparck;
    [SerializeField] Sprite[] hitSprites;

    //cashed ref
    [SerializeField] private Level level;

    //state var
    [SerializeField] int timesHit;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        CountBreakableBlock();
    }

    private void CountBreakableBlock()
    {
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Vector3 SoundLocation = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                destroyBlock();
            }else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        //level.IncreaseScore();  //Fix scoring system
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void destroyBlock()
    {
        Audio();
        TriggerSparkleVfx();
        level.DestroyBlocks();
        Destroy(gameObject);
    }

    private void Audio()
    {
        Vector3 CameraLocation = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(BreakSound, CameraLocation);
    }

    private void TriggerSparkleVfx()
    {
        GameObject sparkles = Instantiate(blockSparck, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}

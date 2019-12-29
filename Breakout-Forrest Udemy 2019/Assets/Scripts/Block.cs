using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //configuration params
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] AudioClip clip;
   // [SerializeField] int maxHits=2;
    [SerializeField] Sprite[] hitsprites;

    // cached reference
    LevelScript level;
    GameSessionScript gameStatus;

    //state variables
    [SerializeField] int timesHit; //todo only serialized for debugging


    // Start is called before the first frame update
    void Start()
    {


        //he refactors this into a method, 
        level = FindObjectOfType<LevelScript>();

        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if(tag == "Breakable")
        {
            HandleHit();
        }


    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitsprites.Length;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit;
        if(hitsprites[spriteIndex]!= null)
        {
            GetComponent<SpriteRenderer>().sprite = hitsprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from Array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        gameStatus = FindObjectOfType<GameSessionScript>();

        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
        level.DestroyBlock();
        gameStatus.AddToScore();

        TriggerSparklesVFX();


        Destroy(gameObject);
        
        //this is how i wanted to do it, apparently im missing something
        //use gameObject instead of this
        /*
        if (collision.collider.name == "Ball")
        {
            Destroy(this);
        }
        */
    }
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX,transform.position,transform.rotation);
        Destroy(sparkles, 2f);
    }
}

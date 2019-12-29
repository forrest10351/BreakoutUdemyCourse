using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    
    [SerializeField] int numberOfBlocks; // serialized for debugging purposes
    // Start is called before the first frame update

    //Cached Reference
    SceneLoader sceneLoader;
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CountBreakableBlocks()
    {
        numberOfBlocks++;


       // int blockCount;
       // blockCount = 1;
       // return blockCount;
    }
    public void DestroyBlock()
    {
        numberOfBlocks--;
        WinLevelCheck();
    }
    void WinLevelCheck()
    {
        if(numberOfBlocks == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}

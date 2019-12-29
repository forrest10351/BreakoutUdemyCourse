using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    
    private void Start()
    {
        
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadFirstScene()
    {
        
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSessionScript>().ResetGame();
        Debug.Log("load first level");
    }
    public void Quit()
    {
        Application.Quit();
    }
  


}

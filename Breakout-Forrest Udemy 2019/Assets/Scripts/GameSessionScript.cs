using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSessionScript : MonoBehaviour
{
    //configuration params
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 20;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    //State Variables
    [SerializeField] int currentScore=0; // serialized for debugging 
   

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSessionScript>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
        Time.timeScale = gameSpeed;
    }
    public void AddToScore()
    {
        
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();

       // scoreText.text = "" + currentScore; // there has to be a better way to (perhaps cast) use the current Score variable as a string
    }


    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}

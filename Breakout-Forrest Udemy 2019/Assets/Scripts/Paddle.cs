using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float ScreenUnits = 16f;
    [SerializeField] float ScreenMin = .8f;
    [SerializeField] float ScreenMax = 15.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this is the way he wanted us to do it. i think it is effectively the same as what i did below.
       
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        
        paddlePos.x = Mathf.Clamp(GetXPos(), ScreenMin, ScreenMax);
        transform.position = paddlePos;



        //this is how i intially got the paddle to move per the challenge
        /*
        float MoveX = (Input.mousePosition.x / Screen.width * ScreenUnits)-transform.position.x;
        Debug.Log(Input.mousePosition.x/Screen.width*ScreenUnits);
        Vector2 paddlePos = new Vector2(transform.position.x+MoveX, transform.position.y);
        transform.position = paddlePos;
        */
    }

    private float GetXPos()
    {
        //should factor out or "cache a variable" for these 2 items bc the function is called in update and is a bit expensive when it comes to processing
        if (FindObjectOfType<GameSessionScript>().IsAutoPlayEnabled())
        {
            return FindObjectOfType<Ball>().transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenUnits;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FingerBehaviour : MonoBehaviour
{

    int Bottomcount; //this is the number of "finger wags" the player has finished. 
    int TopCount; //there are two of these so the player has to hit both boxes enough times to win, otherwise they could just spam the top or bottom box
    public int finishLine; //setting public "finnish line" so I can easily edit how difficult the game is from unity
    private float timer;

    void Start()
    {
        Bottomcount = 0;
        TopCount = 0;
        timer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();
        timeLimit();

        if(Bottomcount >= finishLine && TopCount >= finishLine) //If both win counters are equal too or higher than the "finish line" the game ends
        {
            MoodBehaviour.Instance.hygiene += 10f;
            SceneManager.LoadScene("MenuScene"); //Load the menu scene
        }
    }

    void faceMouse() //creating function to face the sprite towards the mouse
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //setting the mouse to world position not screen position

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.x - transform.position.y); //creating vector pointing towards the mouse position on screen

        transform.up = direction; //setting the top of the sprite to point towards the mouse
    }

    void timeLimit()
    {
        timer = timer - 1 * Time.deltaTime; //setting time limit for the game

        if (timer <= 0)
        {
            SceneManager.LoadScene("MenuScene"); //If the timer runs out the player is pulled back into the menu without the bonus
            Debug.Log("loss");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        if (other.gameObject.tag == "HitBoxBottom")
        {
            Bottomcount = Bottomcount + 1; //Whenever the bottom hit box is hit, the game will tell me in the console and add 1 to the wag count
            Debug.Log("Bottom hit, wag count:" + Bottomcount);
        }

        if (other.gameObject.tag == "HitBoxTop")
        {
            TopCount = TopCount + 1;
            Debug.Log("Top hit, wag count:" + TopCount);
        }

    }

}
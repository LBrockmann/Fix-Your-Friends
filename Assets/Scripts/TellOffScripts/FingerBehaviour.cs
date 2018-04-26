using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FingerBehaviour : MonoBehaviour
{

    int Bottomcount; //this is the number of "finger wags" the player has finished. 
    int TopCount; //there are two of these so the player has to hit both boxes enough times to win, otherwise they could just spam the top or bottom box
    public int finishLine; //setting public "finnish line" so I can easily edit how difficult the game is from unity

    void Start()
    {
        Bottomcount = 0;
        TopCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        faceMouse();
        creepinessCurve();

        if (Bottomcount >= finishLine && TopCount >= finishLine) //If both win counters are equal too or higher than the "finish line" the game ends
        {
            MoodBehaviour.Instance.hygiene += 20f;
            MoodBehaviour.Instance.happiness -= 10f;
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

    void creepinessCurve()
    {
        if (MoodBehaviour.Instance.happiness <= 20)
        {
            finishLine = 100;
        }
        if (MoodBehaviour.Instance.happiness >= 20 && MoodBehaviour.Instance.happiness <= 40)
        {
            finishLine = 40;
        }
        if (MoodBehaviour.Instance.happiness >= 40 && MoodBehaviour.Instance.happiness <= 60)
        {
            finishLine = 30;
        }
        if (MoodBehaviour.Instance.happiness >= 80 && MoodBehaviour.Instance.happiness <= 100)
        {
            finishLine = 20;
        }
        if (MoodBehaviour.Instance.happiness >= 100 && MoodBehaviour.Instance.happiness <= 11)
        {
            finishLine = 10;
        }
    }
}
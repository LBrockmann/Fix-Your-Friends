using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    private float timer;

    // Use this for initialization
    void Start()
    {
        timer = 5; //resetting timer whenever mini game opens
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer-1 * Time.deltaTime; //setting time limit for the game
        Debug.Log(timer);

        if (timer <= 0)
        {
            SceneManager.LoadScene("MenuScene"); //If the timer runs out the player is pulled back into the menu without the bonus
        }
    }

    void OnTriggerEnter2D(Collider2D other) //Creating function for finish line in the running race
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collided"); 
            SceneManager.LoadScene("MenuScene"); //When the player crosses the finish line they should be pulled straight back to the menu
            //Add onto the player stats somehow
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    

    // Use this for initialization
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    void OnTriggerEnter2D(Collider2D other) //Creating function for finish line in the running race
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collided");
            MoodBehaviour.Instance.excersize += 10f;
            MoodBehaviour.Instance.happiness -= 5f;
            SceneManager.LoadScene("MenuScene"); //When the player crosses the finish line they should be pulled straight back to the menu
            //Add onto the player stats somehow
        }
    }
}

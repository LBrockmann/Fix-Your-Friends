using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    SpriteRenderer Player;
    public float PlayerSpeed; //creating public float to easily edit how many clicks required to move the player 
    public float Acceleration;
    public float Resistance; //creating public float for easy access
    public Vector2 StartPos; //Vector just to ensure the player starts in the right spot
    public Rigidbody2D rb; //declaring rigid body



    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); //calling the rigid body
        this.GetComponent<Transform>().position = StartPos; //setting start position just in case
        PlayerSpeed = 0.1f;
    }


    void Update()
    {
        {
            creepinessCurve();
            PlayerSpeed = -Resistance*Time.deltaTime;  //Gradually decreases the power of the force so the player is forced to mash the button faster than this line decreases the force 
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerSpeed = PlayerSpeed + Acceleration; //Whenever players hit the space button the movement speed increases by 1, giving the illusion of "gaining momentum"
                rb.AddForce(new Vector2(PlayerSpeed, 0), ForceMode2D.Impulse);
            }

        }
    }

    void creepinessCurve() //Just decreasing the amount of force behind each push as the game continues so eventually its almost impossible to move your friend
    {
        if (MoodBehaviour.Instance.creepiness <= 50)
        {
            Acceleration = 2;
        }
        if (MoodBehaviour.Instance.creepiness >= 51 && MoodBehaviour.Instance.creepiness <= 100)
        {
            Acceleration = 1;
        }
        if (MoodBehaviour.Instance.creepiness >= 101 && MoodBehaviour.Instance.creepiness <= 200)
        {
            Acceleration = 0.8f;
        }
        if (MoodBehaviour.Instance.creepiness >= 201 && MoodBehaviour.Instance.creepiness <= 300)
        {
            Acceleration = 0.4f;
        }
        if (MoodBehaviour.Instance.creepiness >= 301 && MoodBehaviour.Instance.creepiness <= 350)
        {
            Acceleration = 0.01f;
        }
    }
}


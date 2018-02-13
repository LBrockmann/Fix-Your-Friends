using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    SpriteRenderer playerSprite;
    public float PlayerSpeed; //creating public float to easily edit how many clicks required to move the player 
    public float Resistance; //creating public float for easy access
    public Vector2 StartPos; //Vector just to ensure the player starts in the right spot
    public Rigidbody2D rb; //declaring rigid body



    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); //calling the rigid body
        this.GetComponent<Transform>().position = StartPos; //setting start position just in case
        PlayerSpeed = 0.1f;
        playerSprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        {
            PlayerSpeed = -Resistance*Time.deltaTime;  //Gradually decreases the power of the force so the player is forced to mash the button faster than this line decreases the force 
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerSpeed = PlayerSpeed + 1f; //Whenever players hit the space button the movement speed increases by 1, giving the illusion of "gaining momentum"
                rb.AddForce(new Vector2(PlayerSpeed, 0), ForceMode2D.Impulse);
            }

        }
    }
}

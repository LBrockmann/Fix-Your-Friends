using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    SpriteRenderer Player;
    SpriteRenderer playerhomeSprite;
    public GameObject head;
    public float PlayerSpeed; //creating public float to easily edit how many clicks required to move the player 
    public float Acceleration;
    public float Resistance; //creating public float for easy access
    public Vector2 StartPos; //Vector just to ensure the player starts in the right spot
    public Rigidbody2D rb; //declaring rigid body

    public Sprite greenState;
    public Sprite yellowState;
    public Sprite blueState;
    public Sprite magentaState;
    public Sprite greyState;
    public Sprite blackState;


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
            express();
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
        if (MoodBehaviour.Instance.happiness <= 20)
        {
            Acceleration = 0.01f;
        }
        if (MoodBehaviour.Instance.happiness >= 20 && MoodBehaviour.Instance.happiness <= 40)
        {
            Acceleration = 0.8f;
        }
        if (MoodBehaviour.Instance.happiness >= 40 && MoodBehaviour.Instance.happiness <= 80)
        {
            Acceleration = 1f;
        }
        if (MoodBehaviour.Instance.happiness >= 80 && MoodBehaviour.Instance.happiness <= 100)
        {
            Acceleration = 1.3f;
        }
        if (MoodBehaviour.Instance.happiness >= 100 && MoodBehaviour.Instance.happiness <= 120)
        {
            Acceleration = 2f;
        }
    }

         void express()

        {
            if (MoodBehaviour.Instance.happiness <= 99 && MoodBehaviour.Instance.happiness >= 80)
            {
                head.GetComponent<SpriteRenderer>().sprite = greenState;
            }
            if (MoodBehaviour.Instance.happiness <= 79 && MoodBehaviour.Instance.happiness >= 60)
            {
                head.GetComponent<SpriteRenderer>().sprite = yellowState;
            }
            if (MoodBehaviour.Instance.happiness <= 59 && MoodBehaviour.Instance.happiness >= 40)
            {
                head.GetComponent<SpriteRenderer>().sprite = blueState;
            }
            if (MoodBehaviour.Instance.happiness <= 39 && MoodBehaviour.Instance.happiness >= 20)
            {
                head.GetComponent<SpriteRenderer>().sprite = magentaState;
            }
            if (MoodBehaviour.Instance.happiness <= 19 && MoodBehaviour.Instance.happiness >= 11)
            {
                head.GetComponent<SpriteRenderer>().sprite = greyState;
            }
            if (MoodBehaviour.Instance.happiness <= 10 && MoodBehaviour.Instance.happiness >= 1)
            {
                head.GetComponent<SpriteRenderer>().sprite = blackState;
            }
            if (MoodBehaviour.Instance.happiness <= 0)
            {
                head.GetComponent<SpriteRenderer>().sprite = blackState;
            }
        

    }
}


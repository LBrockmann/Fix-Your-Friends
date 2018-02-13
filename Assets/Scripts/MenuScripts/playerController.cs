using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
    SpriteRenderer playerhomeSprite;

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode start;

    public Text hudText;

    private Rigidbody2D theRB;

	// Use this for initialization
	void Start () {
        theRB = GetComponent<Rigidbody2D>();
        playerhomeSprite = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        Expression();
        if (hudText)
        {
            hudText.text = ("excersize: " + MoodBehaviour.Instance.excersize + " hygiene: " + MoodBehaviour.Instance.hygiene);
        }


        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }

        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
      else
       {
            theRB.velocity = new Vector2(0, theRB.velocity.y); //What's going on here?
        }

        if (Input.GetKeyDown(jump))
        {
            theRB.velocity = new Vector2(moveSpeed, jumpForce);
        }
        
        
	}

    void Expression()
    {
        if (MoodBehaviour.Instance.happiness <= 99 && MoodBehaviour.Instance.happiness >= 80)
        {
            playerhomeSprite.color = Color.green;
        }
        if (MoodBehaviour.Instance.happiness <= 79 && MoodBehaviour.Instance.happiness >= 60)
        {
            playerhomeSprite.color = Color.yellow;
        }
        if (MoodBehaviour.Instance.happiness <= 59 && MoodBehaviour.Instance.happiness >= 40)
        {
            playerhomeSprite.color = Color.blue;
        }
        if (MoodBehaviour.Instance.happiness <= 19 && MoodBehaviour.Instance.happiness >= 11)
        {
            playerhomeSprite.color = Color.grey;
        }
        if (MoodBehaviour.Instance.happiness <= 10 && MoodBehaviour.Instance.happiness >= 1)
        {
            playerhomeSprite.color = Color.black;
        }
        if (MoodBehaviour.Instance.happiness <= 0)
        {
            Debug.Log("game over");
        }
    }
}

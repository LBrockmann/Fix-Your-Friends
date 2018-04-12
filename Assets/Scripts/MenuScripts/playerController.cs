using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
    SpriteRenderer playerhomeSprite;
    public GameObject head;

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode start;

    public Sprite greenState;
    public Sprite yellowState;
    public Sprite blueState;
    public Sprite magentaState;
    public Sprite greyState;
    public Sprite blackState;

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

	//void Shoot1 () {
		//Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		//Vector2 firedirectionPosition = new Vector2 (firedirection1.position.x, firedirection1.position.y);
		
		//GameObject bulletS = Instantiate (BulletSpritePrefab, firePoint.position, firePoint.rotation);
		//bulletS.GetComponent<BulletScript> ().myCaster = this.gameObject;
		//GetComponent<Rigidbody2D>().AddForce ((firedirectionPosition-firePointPosition).normalized*10, ForceMode2D.Impulse);
		
	//}


    void Expression()
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
        if(MoodBehaviour.Instance.happiness <= 39 && MoodBehaviour.Instance.happiness >= 20)
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

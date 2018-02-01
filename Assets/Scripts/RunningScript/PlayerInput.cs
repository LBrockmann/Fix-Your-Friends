using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    SpriteRenderer Player;
    public float PlayerSpeed;
    public Vector2 StartPos;
    public Rigidbody2D rb;



    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        this.GetComponent<Transform>().position = StartPos;
        PlayerSpeed = 0.1f;
    }


    void Update()
    {
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerSpeed = PlayerSpeed + 1f;
                rb.AddForce(new Vector2(PlayerSpeed, 0), ForceMode2D.Impulse);
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FridgeClick : MonoBehaviour
{

    public Sprite fridgeclosed;
    public Sprite fridgeGood;
    public Sprite fridgeBad;
    public Sprite fridgeempty;
    public GameObject fridgeOpen;
    bool hideshowFridge;

    SpriteRenderer fridgerenderer;

    // Use this for initialization
    void Start()
    {
        hideshowFridge = false;
    }

    // Update is called once per frame
    void Update()
    {

        this.GetComponent<Button>().onClick.AddListener(onFridgeClick);

        if (hideshowFridge == true)
        {
            if (MoodBehaviour.Instance.happiness <= 120 && MoodBehaviour.Instance.happiness >= 80)
            {
                fridgeOpen.GetComponent<SpriteRenderer>().sprite = fridgeGood;
            }
            else if (MoodBehaviour.Instance.happiness <= 80 && MoodBehaviour.Instance.happiness >= 50)
            {
                fridgeOpen.GetComponent<SpriteRenderer>().sprite = fridgeempty;
            }
            else if (MoodBehaviour.Instance.happiness <= 80 && MoodBehaviour.Instance.happiness >= 50)
            {
                fridgeOpen.GetComponent<SpriteRenderer>().sprite = fridgeBad;
            }
        }
        else
        {
            fridgeOpen.GetComponent<SpriteRenderer>().sprite = fridgeclosed;
        }

    }

    public void onFridgeClick()
    {
        if(hideshowFridge != true)
        {
            hideshowFridge = true;
        }
        else
        {
            hideshowFridge = false;
        }
    }
}


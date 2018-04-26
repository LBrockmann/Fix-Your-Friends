using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureFunctions : MonoBehaviour
{
    public Sprite fridgeclosed;
    public Sprite fridgeGood;
    public Sprite fridgeBad;
    public Sprite fridgeempty;
    public GameObject fridgeOpen;

    public Sprite ovenStandard;
    public Sprite ovenChicken;
    public Sprite ovenEmpty;
    public GameObject Oven;

    public Sprite cabinatestandard;
    public Sprite cabinatecookies;
    public Sprite cabinateTomato;
    public Sprite cabinateempty;
    public GameObject cabinate;

    public Sprite bedStandard;
    public Sprite bedUnmade;
    public GameObject bed;

    bool hideshowFridge;
    bool hideshowCabinate;
    bool hideshowDrawer;
    bool bedMade;
    bool hideshowOven;

    public AudioSource doorKnock;
    public AudioSource fridgeOpening;
    public AudioSource fridgeClose;
    public AudioSource ovenOpen;
    public AudioSource ovenClose;
    public AudioSource windowTap;
    public AudioSource cabinetOpen;
    public AudioSource cabinetClose;
    public AudioSource drawer;

    SpriteRenderer fridgerenderer;

    // Use this for initialization
    void Start()
    {
        hideshowFridge = false;
        hideshowOven = false;
        hideshowCabinate = false;
        if (MoodBehaviour.Instance.happiness <= 85 && MoodBehaviour.Instance.happiness >= 0)
        {
            bedMade = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (hideshowFridge == true)
        {
            if (MoodBehaviour.Instance.happiness <= 120 && MoodBehaviour.Instance.happiness >= 60)
            {
                fridgeOpen.GetComponent<Image>().sprite = fridgeGood;
            }
            else if (MoodBehaviour.Instance.happiness <= 60 && MoodBehaviour.Instance.happiness >= 40)
            {
                Debug.Log("empty");
                fridgeOpen.GetComponent<Image>().sprite = fridgeempty;
            }
            else if (MoodBehaviour.Instance.happiness <= 40 && MoodBehaviour.Instance.happiness >= 0)
            {
                fridgeOpen.GetComponent<Image>().sprite = fridgeBad;
            }
        }
        else
        {
            fridgeOpen.GetComponent<Image>().sprite = fridgeclosed;
        }

        if (hideshowOven == true)
        {
            if (MoodBehaviour.Instance.happiness <= 120 && MoodBehaviour.Instance.happiness >= 80)
            {
                Oven.GetComponent<Image>().sprite = ovenChicken;
            }
            else if (MoodBehaviour.Instance.happiness <= 80 && MoodBehaviour.Instance.happiness >= 0)
            {
                Oven.GetComponent<Image>().sprite = ovenEmpty;
            }
        }
        else
        {
            Oven.GetComponent<Image>().sprite = ovenStandard;
        }
        

        if (hideshowCabinate == true)
        {
            if (MoodBehaviour.Instance.happiness <= 120 && MoodBehaviour.Instance.happiness >= 50)
            {
                cabinate.GetComponent<Image>().sprite = cabinateTomato;
            }
            else if (MoodBehaviour.Instance.happiness <= 50 && MoodBehaviour.Instance.happiness >= 30)
            {
                Debug.Log("empty");
                cabinate.GetComponent<Image>().sprite = cabinatecookies;
            }
            else if (MoodBehaviour.Instance.happiness <= 30 && MoodBehaviour.Instance.happiness >= 0)
            {
                cabinate.GetComponent<Image>().sprite = cabinateempty;
            }
        }
        else
        {
            cabinate.GetComponent<Image>().sprite = cabinatestandard;
        }

        if (bedMade == true && MoodBehaviour.Instance.happiness <= 120 && MoodBehaviour.Instance.happiness >= 85)
        {
            bed.GetComponent<Image>().sprite = bedStandard;
        }
        

    }

        

    

    public void onFridgeClick()
    {
        if (hideshowFridge != true)
        {
            hideshowFridge = true;
            fridgeOpening.Play();
        }
        else
        {
            hideshowFridge = false;
            fridgeClose.Play();
        }
    }
    public void onBedClick()
    {
        if (bedMade != true)
        {
            bedMade = true;
        }
        else
        {
            bedMade  = false;
        } 
    }
    public void onOvenClick()
    {
        if (hideshowOven != true)
        {
            hideshowOven = true;
            ovenOpen.Play();
        }
        else
        {
            hideshowOven = false;
            ovenClose.Play();
        }
    }
    public void onCabinateClick()
    {
        if (hideshowCabinate != true)
        {
            hideshowCabinate = true;
            cabinetOpen.Play();
        }
        else
        {
            hideshowCabinate = false;
            cabinetClose.Play();
        }
    }
    public void onWindowClick()
    {
        windowTap.Play();
    }
    public void onDoorClick()
    {
        doorKnock.Play();
    }
 
}

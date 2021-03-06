﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FingerTimer : MonoBehaviour { //image and text should both be light up, why are they not? I can't drag things into the inspector either
    public Text onScreenText;
    private string tutorialText = "Wag Your Finger to Tell Them Off!";
    private string lossText = "Too Slow!";
    Image timerBar;
    public float maxTime = 5f;
    float timeLeft;

    bool hasSwitchedBack = false;

    // Use this for initialization
    void Start () {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        onScreenText.text = tutorialText;
    }
	
	// Update is called once per frame
	void Update () {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            hasSwitchedBack = true;

           
        }


        if(hasSwitchedBack)
        {
            hasSwitchedBack = false;
            onScreenText.text = lossText;
            //Time.timeScale = 0;
            SceneManager.LoadScene("MenuScene"); //If the timer runs out the player is pulled back into the menu without the bonus
            Debug.Log("Loss");
            MoodBehaviour.Instance.happiness -=5;
        }

    }
}

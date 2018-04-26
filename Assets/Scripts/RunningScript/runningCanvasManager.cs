using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class runningCanvasManager : MonoBehaviour {
    public Text onScreenText;
    private string tutorialText = "Mash Space to Make Him Run!";
    private string lossText = "Too Slow!";
    Image timerBar;
    public float maxTime = 5f;
    float timeLeft;

    bool hasSwitchedBack = false;
   

	// Use this for initialization
	void Start () {
        
        timerBar = GetComponent<Image>(); //loading image of timer bar
        timeLeft = maxTime; //resetting timer at the begining of  each mini game
        onScreenText.text = tutorialText; //when game opens, start on tutorial teaching texts
	}
	
	// Update is called once per frame
	void Update () {
		if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;  //drain the timer bar
        }
        else
        {
            hasSwitchedBack = true;
        }

        if (hasSwitchedBack)
        {
            hasSwitchedBack = false;
            //Add wait a bit here
            onScreenText.text = lossText;
            SceneManager.LoadScene("MenuScene"); //If the timer runs out the player is pulled back into the menu without the bonus
            Debug.Log("Loss");
            MoodBehaviour.Instance.happiness -= 8; //if the player loses, they make their friend feel bad for being unable to complete the task so they lose happiness
        }
	}
}

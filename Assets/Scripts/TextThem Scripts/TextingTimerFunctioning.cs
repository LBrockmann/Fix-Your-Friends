using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextingTimerFunctioning : MonoBehaviour {

    public Text onScreenText;
    private string tutorialText = "Type out messages and hit enter to send them to your friend!";
    private string lossText = "Too Slow!";
    Image timerBar;
    public float maxTime = 5f;
    float timeLeft; //
    bool restartReady;

    bool hasSwitchedBack = false;


    // Use this for initialization
    void Start()
    {

        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        onScreenText.text = tutorialText;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
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
            restartReady = true;
  restartReady = false;
                SceneManager.LoadScene("MenuScene"); //If the timer runs out the player is pulled back into the menu without the bonus
                Debug.Log("Loss");
            
        }
    }

     IEnumerator waitTimer()
    {
        yield return new WaitForSeconds(1);
    }
}

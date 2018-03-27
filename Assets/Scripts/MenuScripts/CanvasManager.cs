using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour {

    public Text runButton; //Setting up text so the button can change what it is labeled as when it is pressed
    public Text wagButton;
    public Text textButton;
    bool runButtonPressed;
    bool wagButtonPressed;
    bool textButtonPressed;
    bool helpButtonPressed;
    bool helpresetBool;
    private float timer1;
    private float timer2;

    public GameObject panel;

    public Button help;

    // Use this for initialization
    void Start() {
        runButtonPressed = false;
        wagButtonPressed = false;
        textButtonPressed = false;
        helpButtonPressed = false;

    }

    // Update is called once per frame
    void Update() {

        if(runButtonPressed == true)
        {
            Debug.Log("ButtonPressed");
            runButton.text = "please";
            SceneManager.LoadScene("RunningScene"); //Whenever button is pushed, please should breifly be shown before loading the running game
        }

       if(wagButtonPressed == true)
        {
            Debug.Log("ButtonPressed");
            wagButton.text = "stop";
            SceneManager.LoadScene("TellOffScene"); //Whenever button is pushed, stop should breifly be shown before loading the wagging game
        }

       if(textButtonPressed == true)
        {
            Debug.Log("ButtonPressed");
            textButton.text = "It's okay";
            SceneManager.LoadScene("TextScreen");
        }

       if(helpButtonPressed == true)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
        
    }
    //Button Functions
    public void OnRunButtonPressed()
    {
        runButtonPressed = true;
    }

    public void OnWagButtonPressed()
    {
        wagButtonPressed = true;
    }

    public void OnTextButtonPressed()
    {
        textButtonPressed = true;
    }

    public void OnHelpButtonPressed()
    {
        if (helpButtonPressed != true)
        {
            helpButtonPressed = true;
        }
        else
        {
            helpButtonPressed = false;
        }
    }

    public void onRestartButtonPressed()
    {
        MoodBehaviour.Instance.happiness = 20;
        MoodBehaviour.Instance.creepiness = 0;
        MoodBehaviour.Instance.happiness = 50;
        MoodBehaviour.Instance.hygiene = 50;
        MoodBehaviour.Instance.friendship = 50;
        MoodBehaviour.Instance.excersize = 50;

        SceneManager.LoadScene("Opening Scene");
    }

}

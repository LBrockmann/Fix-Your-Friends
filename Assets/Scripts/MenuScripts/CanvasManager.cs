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
    private float timer1;
    private float timer2;

    // Use this for initialization
    void Start() {
        runButtonPressed = false;
        wagButtonPressed = false;
        textButtonPressed = false;
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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour {

    public Text runButton; //Setting up text so the button can change what it is labeled as when it is pressed
    public Text wagButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //Button Functions
    public void OnRunButtonPressed ()
    {
        Debug.Log("ButtonPressed");
        runButton.text = "please";
        SceneManager.LoadScene("RunningScene"); //Whenever button is pushed, please should breifly be shown before loading the running game
    }

    public void OnWagButtonPressed ()
    {
        Debug.Log("ButtonPressed");
        wagButton.text = "stop";
        SceneManager.LoadScene("TellOffScene"); //Whenever button is pushed, stop should breifly be shown before loading the wagging game
    }
}

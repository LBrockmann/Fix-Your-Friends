using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoodBehaviour : MonoBehaviour { //Dear luke, you are halfway through designing the drain system. You need to find a way of saving the int. Also test the draining system, and randomsize the float that they drain by

    public float hygiene;
    public float excersize;

    public float hygieneLoss;
    public float excersizeLoss;

    public Text guiText;

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        //Set different loss rates to a random number
        drain();
        guiText.text = ("excersize: " + excersize + " hygiene: " + hygiene);
    }

    void drain ()
    {
        Scene currentScene = SceneManager.GetActiveScene(); //Creating reference to scene names
        string sceneName = currentScene.name; //Creating string filled with whatever the open scene name is called

        if (sceneName == "MenuScene"){
            hygiene -= hygieneLoss*Time.deltaTime; //If the menu scene is open, each variable should slowly decrease by its randomly determined loss rate
            excersize -= excersizeLoss*Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    public Text runButton;
    public Text wagButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnRunButtonPressed ()
    {
        Debug.Log("ButtonPressed");

        runButton.text = "please"; 
    }
}

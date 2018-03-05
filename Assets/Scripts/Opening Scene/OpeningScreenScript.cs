using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(MoodBehaviour.Instance.playerUnderstands == 1)
        {
            GameObject.Find("StartGameButton").GetComponentInChildren<Text>().text = "Help Your Friend";
        }
        else
        {
            GameObject.Find("StartGameButton").GetComponentInChildren<Text>().text = "Fix Your Friend";
        }
	}

    public void callMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

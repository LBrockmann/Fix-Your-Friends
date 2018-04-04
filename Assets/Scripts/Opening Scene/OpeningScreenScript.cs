using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningScreenScript : MonoBehaviour {

    public AudioSource buttonpresssound;
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
        buttonpresssound.Play();
        StartCoroutine(sceneLoading("MenuScene"));
    }

    private IEnumerator sceneLoading(string whatisloading)
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(whatisloading);
    }
}

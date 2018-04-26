using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour {

    public Text runButton; //Setting up text so the button can change what it is labeled as when it is pressed
    public Text wagButton;
    public Text textButton;
    bool helpButtonPressed;
    bool helpresetBool;
    private float timer1;
    private float timer2;

    public AudioSource buttonAudioSource;
    public AudioSource backgroundnoise;

    public GameObject panel;

    public Button help;

    // Use this for initialization
    void Start() {
        helpButtonPressed = false;
        backgroundnoise.Play();
    }

    // Update is called once per frame
    void Update() {

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
        buttonAudioSource.Play();
        Debug.Log("ButtonPressed");
        StartCoroutine(sceneLoading("RunningScene"));
    }

    public void OnWagButtonPressed()
    {
        buttonAudioSource.Play();
        
        Debug.Log("ButtonPressed");
        StartCoroutine(sceneLoading("TellOffScene"));
    }

    public void OnTextButtonPressed()
    {
        buttonAudioSource.Play();
        Debug.Log("ButtonPressed");
        textButton.text = "It's okay";
        //SceneManager.LoadScene("TextScreen");
        StartCoroutine(sceneLoading("TextScreen"));

    }

    public void OnHelpButtonPressed()
    {
        buttonAudioSource.Play();
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
        buttonAudioSource.Play();
        MoodBehaviour.Instance.happiness = 60;
        MoodBehaviour.Instance.creepiness = 0;
        MoodBehaviour.Instance.happiness = 50;
        MoodBehaviour.Instance.hygiene = 50;
        MoodBehaviour.Instance.friendship = 50;
        MoodBehaviour.Instance.excersize = 50;
        
        SceneManager.LoadScene("Opening Scene");
    }

    private IEnumerator sceneLoading(string whatisloading)
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(whatisloading);
    }


}

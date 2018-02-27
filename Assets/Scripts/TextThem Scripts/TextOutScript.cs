using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextOutScript : MonoBehaviour {

    public string[] messages;
    public Text playerMessages;
    public Image messageBox;
    public GameObject pannel;

    public int messagesSent;

    public Text inputText;
    private int rNum;

    int i = 0;

    // Use this for initialization
    void Start () {
        rNum = Random.Range(0, messages.Length);

        messages = new string[15];
        messages[0] = "Hey";
        messages[4] = "<3";
        messages[5] = "Have you been for a run today?";
        messages[6] = "Yo, so I was reading up in this magazine and apparently, you can reduce depressoin up to 40 PERCENT!! All you have to do is make your bed in the morning.";
        messages[7] = "We're worried about you. ";
        messages[8] = "Hey, I just wanted to ask you how you've been doing. Super worried about you!";
        messages[1] = "I know you're depressed and all but that doesn't mean you can just shut me out.";
        messages[2] = "What's up? How you doin! We should totally go out sometime! Hit me up.";
        messages[3] = "Thinking about you!";
        messages[9] = "Is it because you don't trust me or something? I can keep a secret";
        messages[10] = "Happiness is just an attitude!";
        messages[11] = "Did you cut? Send me photos.";
        messages[12] = "Where have you been? Are you ignoring me?";
        messages[13] = "Why won't you hang out with us any more?";
        messages[14] = "You're being dramatic. Everyone hates stuff like their voice. It's normal.";

        messagesSent = 0;
    }

    // Update is called once per frame
    void Update () {
		if(Input.anyKeyDown)
        {
            if (i < messages[rNum].Length)
            {
                inputText.text += messages[rNum][i].ToString();
                Debug.Log(i + " " + rNum + " " + messages[rNum].Length);
                i++;
            }
            else if(i == messages[rNum].Length && Input.GetKeyDown(KeyCode.Return))
            {
                messagesSent++;
                typingmessages(messages[rNum]);
                inputText.text = "";
                rNum = Random.Range(0, messages.Length);
                i = 0;
            }
            if (messagesSent >= 3)
            {
                SceneManager.LoadScene("MenuScene");
                MoodBehaviour.Instance.friendship += 10f;
                MoodBehaviour.Instance.happiness -= 10f;
            }

        }
	}

    public void typingmessages(string msg)
    {
        playerMessages.text = msg;
        Object.Instantiate(messageBox,pannel.transform);
    }
}

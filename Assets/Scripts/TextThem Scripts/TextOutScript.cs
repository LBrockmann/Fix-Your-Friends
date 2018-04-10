using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextOutScript : MonoBehaviour {

    public string[] messages;
    public string[] messagesTwo;
    public string[] messages3;
    public Text playerMessages;
    public Image messageBox;
    public GameObject pannel;

    public AudioSource onTypeSound;
    public AudioSource onSend;
    public int messagesSent;

    public Text inputText;
    private int rNum;

    bool restartReady = false;

    int i = 0;

    // Use this for initialization
    void Start () {
       

        //All of the following code is just narrative text for the story, its the individual arrays the game cycles through as the player goes through the game. 
        messages = new string[15];
        messages[0] = "Hey";
        messages[4] = "<3";
        messages[5] = "Have you been for a run today?";
        messages[6] = "How you sleeping?";
        messages[7] = "We're worried about you.";
        messages[8] = "I just wanted to ask you how you've been doing. Super worried about you!";
        messages[1] = "Missing you heaps! Everyone's asking after you!";
        messages[2] = "What's up? How you doin! We should totally go out sometime! Hit me up.";
        messages[3] = "Thinking about you!";
        messages[9] = "Don't be too hard on yourself! Everyone is special";
        messages[10] = "Happiness is just an attitude!";
        messages[11] = "You can text me whenever you need!";
        messages[12] = "Where have you been? Are you ignoring me?";
        messages[13] = "Why won't you hang out with us any more?";
        messages[14] = "You're being a little dramatic";

        messagesTwo = new string[7];
        messagesTwo[0] = "Hey";
        messagesTwo[1] = "I know you're depressed and all but that doesn't mean you can just shut me out.";
        messagesTwo[2] = "Is it because you don't trust me or something? I can keep a secret";
        messagesTwo[3] = "Did you cut? Send me photos.";
        messagesTwo[4] = "You know when I failed my class last year I hated EVERYTHING. I totally understand how you feel.";
        messagesTwo[5] = "Are you asleep again? ffs. Can you just get up? I'm trying to talk to you.";
        messagesTwo[6] = "Kinda stressing about you. You haven't messaged in a while so I hope you're all good";

        messages3 = new string[6];
        messages3[0] = "Hey";
        messages3[1] = "Okay seriously, what is wrong with you.";
        messages3[2] = "I get it. I really do. I'm just sick of the way you behave. I mean seriously? You think that you can just do what you want because you're depressed?";
        messages3[3] = "I mean come on. You haven't broken a leg, you're not going to fucking die. I just don't understand why it hasn't gotten better at this point. Like are you trying to improve?";
        messages3[4] = "I love you, I'm just tired. I have been trying tirelessly to help you and all you do is push back and resist and make everything harder. You've been so ungrateful of everything I do for you.";
        messages3[5] = "You know what? I'm sick of this. You need to clean up your act. Seriously. I am not going to let you fucking waste your life and your time by being lazy. Get your shit together";

        if (MoodBehaviour.Instance.creepiness <= 100)
        {
            rNum = Random.Range(0, messages.Length);
        }
        else if (MoodBehaviour.Instance.creepiness > 100 && MoodBehaviour.Instance.creepiness <= 250)
        {
            rNum = Random.Range(0, messagesTwo.Length);
        }
        else if (MoodBehaviour.Instance.creepiness > 250 && MoodBehaviour.Instance.creepiness <= 350)
        {
            rNum = Random.Range(0, messages3.Length);
        }

        messagesSent = 0;
    }

   
    void Update () {
        Debug.Log(messagesTwo);
        if (Input.anyKeyDown)
        {
            if(MoodBehaviour.Instance.creepiness <= 100)
            {
                MessageSequenceOne();
            }
            if(MoodBehaviour.Instance.creepiness > 100 && MoodBehaviour.Instance.creepiness <= 250)
            {
                MessageSequenceTwo();
            }
            if(MoodBehaviour.Instance.creepiness > 250 && MoodBehaviour.Instance.creepiness <= 350)
            {
                MessageSequenceThree(); 
            }
            onTypeSound.Play();
        }
	}

    public void typingmessages(string msg)
    {
        playerMessages.text = msg;
        Object.Instantiate(messageBox,pannel.transform);
    }

    public void MessageSequenceOne()
    {
        if (i < messages[rNum].Length)
        {
            inputText.text += messages[rNum][i].ToString();
            Debug.Log(i + " " + rNum + " " + messages[rNum].Length);
            i++;
        }
        else if (i == messages[rNum].Length && Input.GetKeyDown(KeyCode.Return))
        {
            onSend.Play();
            messagesSent++;
            typingmessages(messages[rNum]);
            inputText.text = "";
            rNum = Random.Range(0, messages.Length);
            i = 0;
        }
        if (messagesSent >= 3)
        {
            SceneManager.LoadScene("MenuScene");
            MoodBehaviour.Instance.friendship += 15f;
            MoodBehaviour.Instance.happiness -= 5f;
        }
    }

    public void MessageSequenceTwo()
    {
        if (i < messagesTwo[rNum].Length)
        {
            inputText.text += messagesTwo[rNum][i].ToString();
            Debug.Log(i + " " + rNum + " " + messagesTwo[rNum].Length);
            i++;
        }
        else if (i == messagesTwo[rNum].Length && Input.GetKeyDown(KeyCode.Return))
        {
            onSend.Play();
            messagesSent++;
            typingmessages(messagesTwo[rNum]);
            inputText.text = "";
            rNum = Random.Range(0, messagesTwo.Length);
            i = 0;
        }
        if (messagesSent >= 3)
        {
            SceneManager.LoadScene("MenuScene");
            MoodBehaviour.Instance.friendship += 15f;
            MoodBehaviour.Instance.happiness -= 5f;
        }
    }

    public void MessageSequenceThree()
    {
        if (i < messages3[rNum].Length)
        {
            inputText.text += messages3[rNum][i].ToString();
            i++;
        }
        else if (i == messages3[rNum].Length && Input.GetKeyDown(KeyCode.Return))
        {
            onSend.Play();
            messagesSent++;
            typingmessages(messages3[rNum]);
            inputText.text = "";
            rNum = Random.Range(0, messages3.Length);
            i = 0;
        }
        if (messagesSent >= 3)
        {
            SceneManager.LoadScene("MenuScene");
            MoodBehaviour.Instance.friendship += 15f;
            MoodBehaviour.Instance.happiness -= 5f;
        }
    }
}

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
        messages[5] = ":D";
        messages[6] = ";)";
        messages[7] = "Awesome seeing you yesterday!";
        messages[8] = "How've you been?";
        messages[1] = "Missing you heaps!";
        messages[2] = "What's up? How you doin!";
        messages[3] = "Thinking about you!";
        messages[9] = "How's work?";
        messages[10] = "Miss ya";
        messages[11] = "Yo, movie tonight?";
        messages[12] = "Let's go for a hije";
        messages[13] = "Miss you boo :P?";
        messages[14] = "Caught the game?";

        messagesTwo = new string[7];
        messagesTwo[0] = "Hey";
        messagesTwo[1] = "I'm just really worrried about you";
        messagesTwo[2] = "Is it because you don't trust me?";
        messagesTwo[3] = "Did you cut? Send me photos.";
        messagesTwo[4] = "Why aren't you responding?";
        messagesTwo[5] = "Did I do something wrong?";
        messagesTwo[6] = "You're really freaking me out.";

        messages3 = new string[6];
        messages3[0] = "Hey";
        messages3[1] = "Okay seriously, what is wrong with you.";
        messages3[2] = "I get it. I really do. I'm just sick of the way you behave. I mean seriously? You think that you can just do what you want because you're depressed?";
        messages3[3] = "I mean come on. You haven't broken a leg, you're not going to fucking die. I just don't understand why it hasn't gotten better at this point. Like are you trying to improve?";
        messages3[4] = "I love you, I'm just tired. I have been trying tirelessly to help you and all you do is push back and resist and make everything harder. You've been so ungrateful of everything I do for you.";
        messages3[5] = "You know what? I'm sick of this. You need to clean up your act. Seriously. I am not going to let you fucking waste your life and your time by being lazy. Get your shit together";

        if (MoodBehaviour.Instance.happiness <= 40)
        {
            rNum = Random.Range(0, messages.Length);
        }
        else if (MoodBehaviour.Instance.happiness > 40 && MoodBehaviour.Instance.happiness <= 90)
        {
            rNum = Random.Range(0, messagesTwo.Length);
        }
        else if (MoodBehaviour.Instance.happiness > 90 && MoodBehaviour.Instance.happiness <= 120)
        {
            rNum = Random.Range(0, messages3.Length);
        }

        messagesSent = 0;
    }

   
    void Update () {
        Debug.Log(messagesTwo);
        if (Input.anyKeyDown)
        {
            if(MoodBehaviour.Instance.happiness <= 120 && MoodBehaviour.Instance.happiness > 90)
            {
                MessageSequenceOne();
            }
            if(MoodBehaviour.Instance.happiness > 40 && MoodBehaviour.Instance.happiness <= 90)
            {
                MessageSequenceTwo();
            }
            if(MoodBehaviour.Instance.happiness > 0 && MoodBehaviour.Instance.happiness <= 39)
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
            MoodBehaviour.Instance.happiness -= 10f;
        }
    }
}

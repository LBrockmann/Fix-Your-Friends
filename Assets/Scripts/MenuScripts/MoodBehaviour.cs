using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoodBehaviour : MonoBehaviour
{ 
    //This is a little code that allows me to access this specific code from any scene i need, so all the emotive and game winning ints are here because other mini games affect them
    private static MoodBehaviour instance = null;
    public static MoodBehaviour Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

   
    }

    public float hygiene;
    public float excersize;
    public float friendship;

    public int intervention;
    public float happybalance;
    public float difficultybalance;

    public float creepiness;

    
    public float hygieneLoss;
    public float excersizeLoss;
    public float friendshipLoss;

    public float AllLoss;
    public float randomizer;
    bool timerDone;
    public float Happinesstimer;

    public float happiness;
    public float happinessGain;

    public int playerUnderstands = 0;
    


    // Use this for initialization
    void Start()
    {
        timerDone = false; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Set different loss rates to a random number
        hygieneLoss = Random.Range(1, 5);
        excersizeLoss = Random.Range(1, 3);
        friendshipLoss = Random.Range(1, 7);
        drain();
        joy();
        creepinessScale();

     

    }

    void drain()
    {
        Scene currentScene = SceneManager.GetActiveScene(); //Creating reference to scene names
        string sceneName = currentScene.name; //Creating string filled with whatever the open scene name is called

        if (sceneName == "MenuScene")
        {
            if (hygiene >= 0) { hygiene -= hygieneLoss * Time.deltaTime; } //If the menu scene is open, each variable should slowly decrease by its randomly determined loss rate
            if (excersize >= 0) { excersize -= excersizeLoss * Time.deltaTime; } //If statements added to prevent all ints from dropping into huge negatives
            if (friendship >= 0) { friendship -= friendshipLoss * Time.deltaTime;}
        }
    }
    //Welcome to the secret int section
    void joy() //Joy manages the mechanisms of happiness, what makes it go up and down
    {
        //The Following if statements prevent happiness from increasing immediately, so the player is more likely to decrease it before increasing it, allowing happiness to start high and drop low
        if (Happinesstimer <= 30) {
            Happinesstimer = Happinesstimer += 1 * Time.deltaTime;
        }
        else if (Happinesstimer > 30) {
            timerDone = true;
        }
        //Once the timer is finished, happiness will begin to increase over time
        if (timerDone == true)
        {
            happiness += happinessGain * Time.deltaTime;
        }
        if (happiness >= 120)
        {
            SceneManager.LoadScene("YouDidIt"); //WinState
            Destroy(this.gameObject);
            playerUnderstands = 1; //this should be a bool but i couldn't work out how to call bools from other texts so its just an int that is either 1 or 0. Just a small easter egg
            if(happiness <= 0) //this prevents happiness from dropping below 0
            {
                happiness = 0.1f;
            }
        }

    }

    void creepinessScale ()
    {
        creepiness +=  2 * Time.deltaTime;
        if(creepiness == 350) //this is creepiness. It will continually increase, as, if the player hasn't won, then they are still hurting their friend. Thus the game gets harder, more hectic and more intense based on this one int.
        {
            SceneManager.LoadScene("Game Over");
            Destroy(this.gameObject);
        }
    }

    void cap ()
    {
        if(hygiene > 50)
        {
            hygiene = 50;
        }
        if(friendship > 50)
        {
            friendship = 50;
        }
        if (excersize > 50)
        {
            excersize = 50;
        }
    }

    void escalation()
    {
        AllLoss = ((((100 - happiness) / happybalance) + randomizer) / difficultybalance); //This hopefully will scale its loss based on the happiness int
    }

   
}
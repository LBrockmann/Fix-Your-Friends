using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoodBehaviour : MonoBehaviour
{ //Dear luke, you are halfway through designing the drain system. You need to find a way of saving the int. Also test the draining system, and randomsize the float that they drain by

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

       // QualitySettings.vSyncCount = 0;  // VSync must be disabled
        //Application.targetFrameRate = 45;
    }

    public float hygiene;
    public float excersize;
    public float friendship;

    public float creepiness;

    
    public float hygieneLoss;
    public float excersizeLoss;
    public float friendshipLoss;

    public float happiness;
    public float happinessGain;

    public int playerUnderstands = 0;
    


    // Use this for initialization
    void Start()
    {
        
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
        Debug.Log(creepiness);

        if (Input.GetKeyDown("space"))
        {
            happiness = 130;
        }

     

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

    void joy()
    {
        happiness += happinessGain * Time.deltaTime;
        if (happiness >= 120)
        {
            SceneManager.LoadScene("YouDidIt");
            Destroy(this.gameObject);
            playerUnderstands = 1;
        }
    }

    void creepinessScale ()
    {
        creepiness +=  1 * Time.deltaTime;
        if(creepiness == 400)
        {
            SceneManager.LoadScene("Game Over");
            Destroy(this.gameObject);
        }
    }

   
}
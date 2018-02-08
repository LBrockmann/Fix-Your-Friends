using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMood : MonoBehaviour
{
    [SerializeField]
    private int _Health; //underscore character used in private instances of a variable
    private int _Hygiene;


    // Use this for initialization
    void Start()
    {
        updateMood();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void updateMood() //void for creating save state of mood based ints
    {

        if (!PlayerPrefs.HasKey("_Health"))
        {
            _Health = 100;
            PlayerPrefs.SetInt("_Health", _Health);
        }
        else
        {
            _Health = PlayerPrefs.GetInt("_Health");
        }
        if (!PlayerPrefs.HasKey("_Hygiene"))
        {
            _Hygiene = 100;
            PlayerPrefs.SetInt("_Hygiene", _Hygiene);
        }
        else
        {
            _Hygiene = PlayerPrefs.GetInt("_Hygiene");
        }
    }

    public int Health
    {
        get { return _Health; }
        set { _Health = value; }
    }

    public int Hygiene
    {
        get { return _Hygiene; }
        set { _Hygiene = value; }
    }

}


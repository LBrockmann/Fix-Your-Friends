using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarMenu : MonoBehaviour {

    private float maxPhysHealth = 50f;
    private Image healthBar;

    // Use this for initialization
    void Start () {
        healthBar = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        barManagment();
    }

    public void barManagment()
    {
        healthBar.fillAmount = MoodBehaviour.Instance.excersize / maxPhysHealth;
    }
}

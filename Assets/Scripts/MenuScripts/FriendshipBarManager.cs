using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FriendshipBarManager : MonoBehaviour {

    private float maxFriendship = 50f;
    Image _friendshipbar;

	// Use this for initialization
	void Start () {
        _friendshipbar = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        _friendshipbar.fillAmount = MoodBehaviour.Instance.friendship / maxFriendship;
	}
}

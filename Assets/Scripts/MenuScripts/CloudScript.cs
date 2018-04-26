using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour {

	public GameObject CloudPrefab;
	float x = -10;
	float y = -5;
	float t = 90;
	float cloudSpeed = 0.5f;


    //Small Script made to create real randomized moving clouds in the background

	void Start() {
        //Instantiate(cloud, new Vector2(x, y), Quaternion.identity);
        t = 50;
	}

	void Update (){
		t = t + 0.1f;
			if (t > 50) {
				Cloud ();
			}

		y = y + 1.3f;
		if (y > 5) {
			y = -5;
		}

	}

	public void Cloud (){
		t = 0;
		GameObject cloudS = Instantiate (CloudPrefab, new Vector3 (x, y, 1), Quaternion.identity); 
		cloudS.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (cloudSpeed, 0), ForceMode2D.Impulse);
	}
}



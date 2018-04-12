using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudShitScriptRunning : MonoBehaviour {

	public GameObject CloudPrefab;
	float x = -2;
	float y = 3.5f;
	float t = 98;
	float cloudSpeed = 0.5f;

	void Start() {
		//Instantiate(cloud, new Vector2(x, y), Quaternion.identity);

	}

	void Update (){
		t = t + 0.1f;
		if (t > 100) {
			Cloud ();
		}


	}

	public void Cloud (){
		t = 0;
		GameObject cloudS = Instantiate (CloudPrefab, new Vector3 (x, y, 1), Quaternion.identity);
		cloudS.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (cloudSpeed, 0), ForceMode2D.Impulse);
	}
}

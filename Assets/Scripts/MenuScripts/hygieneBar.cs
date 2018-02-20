using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hygieneBar : MonoBehaviour {

    private float maxHygiene = 50f;
    Image _hygieneBar;

    // Use this for initialization
    void Start () {
        _hygieneBar= GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        _hygieneBar.fillAmount = MoodBehaviour.Instance.hygiene / maxHygiene;
    }
}

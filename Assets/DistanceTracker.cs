using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceTracker : MonoBehaviour {
    public int distanceCounter;
    public float targetAmount;

    public Text distanceText;


    private int counter = 0;
	// Use this for initialization
	void Start () {
        SetText();
	}
	
	// Update is called once per frame
	void Update () {
        // Counts up to the target amount (in seconds) and the distance is
        // incremented and set
        if ((counter++) * Time.deltaTime >= targetAmount) {
            counter = 0;
            distanceCounter++;
            SetText();
        }
	}

    // Sets the text in the scene to the current distance the player has ran
    void SetText() {
        distanceText.text = distanceCounter + "";
    }
}

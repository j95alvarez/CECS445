﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceTracker : MonoBehaviour {
    public bool startGame;

    public int distanceCounter;

    [SerializeField]
    private float targetAmount;

    [SerializeField]
    private Text distanceText;

    [SerializeField]
    private int distanceMaker;

    [SerializeField]
    private GameObject spawner;

    [SerializeField]
    private GameObject antagonist;


    private int counter = 0;
    private WallSpawn ws;

    private EnemyController ec;

	// Use this for initialization
	void Start () {
        SetText();
        ws = spawner.GetComponent<WallSpawn>();
        ec =antagonist.GetComponent<EnemyController>();
	}
	
	// Update is called once per frame
	void Update () {
        // Counts up to the target amount (in seconds) and the distance is
        // incremented and set
        if (startGame && ((counter++) * Time.deltaTime >= targetAmount)) {
            counter = 0;
            distanceCounter++;
            SetText();

            if (distanceCounter % distanceMaker == 0) {
                ws.ChangeSpeed(0.5f);
                ec.ChangeSpeed(0.1f);
            }
        }
	}


    // Sets the text in the scene to the current distance the player has ran
    void SetText() {
        distanceText.text = distanceCounter + "";
    }
}

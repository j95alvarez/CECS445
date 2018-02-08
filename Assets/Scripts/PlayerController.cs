using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public bool startGame;
	public int jumpHeight;
	public bool canJump;

    void Start() {
        startGame = false;
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetButtonDown ("Jump")) {
			if (canJump && startGame) {
				Jump ();
			}
		}
	}

	public void OnCollisionEnter2D (Collision2D other) {
		canJump = true;
	}

	public void OnCollisionExit2D (Collision2D other) {
		canJump = false;
	}
    
	public void Jump(){
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpHeight * Time.timeScale);
	}

}

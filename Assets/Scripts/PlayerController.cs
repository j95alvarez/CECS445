using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public int jumpHeight;
	public bool canJump;


	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			if (canJump == true) {
				Jump ();
			}
		}
	}


	void OnCollisionEnter2D (Collision2D other) 
	{
		canJump = true;
	}

	void OnCollisionExit2D (Collision2D other) 
	{
		canJump = false;
	}



	void Jump(){
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpHeight);
	}

}

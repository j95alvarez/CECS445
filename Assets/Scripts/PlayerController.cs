using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public int jumpHeight;

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump")){
			Jump ();
		}
	}

	void Jump(){
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpHeight);
	}

}

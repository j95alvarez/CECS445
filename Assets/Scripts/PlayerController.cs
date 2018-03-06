using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public bool startGame;
	public int jumpHeight;
	public bool canJump;
	//Boolean variable to keep track of whether the player is alive or not (true is alive, false is dead)
	public bool alive;

	public Animator anim;

    void Start() {
        startGame = false;
		anim = gameObject.GetComponent<Animator> ();
		//Lets us know that the player is alive at the start of the game
		alive = true;
    }

    // Update is called once per frame
    void Update () {
		if (startGame) {
			anim.SetBool ("Running", true);
		}

		if (Input.GetButtonDown ("Jump")) {
			if (canJump) {
				Jump ();
			}
		}
	}

	public void OnCollisionEnter2D (Collision2D other) {
        anim.SetBool("Running", true);
        canJump = true;
        anim.SetBool("Jumping", false);
    }

	public void OnCollisionExit2D (Collision2D other) {
        anim.SetBool("Running", false);
        canJump = false;
	}
    
	public void Jump(){
        anim.SetBool("Jumping", true);
        GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpHeight * Time.timeScale);
        
    }

}

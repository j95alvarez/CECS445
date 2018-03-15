using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	//Initialization and declaration of variables
	public float enemySpeed;
	public int xMoveDirection;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () { 
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (xMoveDirection * enemySpeed, 0);
	}

	void OnCollisionEnter2D(Collision2D collisionObject){
		Debug.Log (collisionObject.gameObject.tag);

        if (collisionObject.gameObject.tag == "Player") {
            //Destroy(collisionObject.gameObject);
            collisionObject.gameObject.GetComponent<PlayerController>().alive = false;
        } else {
            if (!collisionObject.collider.CompareTag("Untagged"))
                Destroy(collisionObject.gameObject);
        }
	}
}

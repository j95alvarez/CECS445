using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	//Initialization and declaration of variables
	public int enemySpeed;
	public int xMoveDirection;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (xMoveDirection, 0) * enemySpeed;
	}

	void OnCollisionEnter2D(Collision2D collisionObject){
		Debug.Log (collisionObject.gameObject.tag); 

		if (collisionObject.gameObject.tag == "Player") {
			Destroy(collisionObject.gameObject);
		}
	}
}

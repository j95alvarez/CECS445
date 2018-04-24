using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	//Initialization and declaration of variables
	public float enemySpeed;
	public int xMoveDirection;

    private Animator anim;
    public bool startGame;

    // Use this for initialization
    void Start () {
        anim = GetComponentInChildren<Animator>();
        startGame = false;
    }

    private void Update() {
        if (startGame)
            anim.SetFloat("speed", 1.0f);
    }
    // Update is called once per frame
    void FixedUpdate () { 
		GetComponent<Rigidbody2D>().velocity = new Vector2 (xMoveDirection * enemySpeed * Time.deltaTime, 0);
	}

	void OnCollisionEnter2D(Collision2D collisionObject){
        if (collisionObject.gameObject.tag == "Player") {
            //Destroy(collisionObject.gameObject);
            collisionObject.gameObject.GetComponent<PlayerController>().alive = false;
        } else {
            if (!collisionObject.collider.CompareTag("Untagged"))
                Destroy(collisionObject.gameObject);
        }
	}
}

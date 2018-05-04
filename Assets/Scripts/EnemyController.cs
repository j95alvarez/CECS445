using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	//Initialization and declaration of variables
	public float enemySpeed;
	public int xMoveDirection;

    private Animator anim;
    public bool startGame;

    private Coroutine delayDestroy;

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
        if (startGame)
            GetComponent<Rigidbody2D>().velocity = new Vector2 (xMoveDirection * enemySpeed , 0);
	}

	void OnCollisionEnter2D(Collision2D collisionObject){
        if (collisionObject.gameObject.tag == "Player") {
            //Destroy(collisionObject.gameObject);
            //collisionObject.gameObject.GetComponent<PlayerController>().alive = false;

            var player = collisionObject.gameObject;
            var pc = player.GetComponent<PlayerController>().alive = false;

            // Adds to the leaderboard
            var distance = player.GetComponent<DistanceTracker>().distanceCounter;
            GooglePlay.AddScoreToGlobalLeaderboard(distance);

        } else {
            if (!collisionObject.collider.CompareTag("Untagged"))
                // Destroy(collisionObject.gameObject);
                if(delayDestroy == null)
                    delayDestroy = StartCoroutine(Delay(collisionObject.gameObject));

        }
	}

    public void ChangeSpeed(float newSpeed)
    {
        //enemySpeed += newSpeed;
    }

    IEnumerator Delay(GameObject g)
    {
        yield return new WaitForSeconds(.2f);
        Destroy(g);
        delayDestroy = null;
    }
}

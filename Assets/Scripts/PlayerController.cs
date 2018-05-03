using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class PlayerController : MonoBehaviour {

    public bool startGame;
	public int jumpHeight;
	public bool canJump;
    private int doubleJump;
    private float slideTime;
    public Vector2 firstPressPos;
    public Vector2 secondPressPos;
    public Vector2 currentSwipe;


    public ObjectDetection od;


    private float timer;

    private BoxCollider2D box; //.collider as BoxCollider;

    //Boolean variable to keep track of whether the player is alive or not (true is alive, false is dead)
    public bool alive;

	private Animator anim;

    void Start() {
        startGame = false;
		anim = GetComponentInChildren<Animator>();
        box = GetComponent<BoxCollider2D>();
        //anim.SetBool("Running", true);
        //anim.SetFloat("speed", 0.1f);
        

        //Lets us know that the player is alive at the start of the game
        alive = true;
    }

    // Update is called once per frame
    void Update () {
        if (startGame)
            anim.SetFloat("speed", 1.0f);
        //Debug.Log(anim.GetBool("Sliding"));
        if (slideTime >= 0.6f)
        {
            ResetRunAnimation();
        }
        else if (anim.GetBool("Sliding") && slideTime < 0.6f)
        {
            slideTime += Time.deltaTime;
        }
        Swipe();
    }

    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                if (canJump && doubleJump < 2)
                {
                    doubleJump += 1;
                    Jump();
                }
            }
            
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                anim.SetBool("Running", false);
                anim.SetBool("Sliding", true);
                box.size = new Vector2(0.6f, 0.6f);
                slideTime += Time.deltaTime;
                box.offset = new Vector2(0, -0.35f);
                Debug.Log("Current BoxCollider Size : " + box.size);
                
            }

            /*
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("attack");

                var wallToDestroy = od.GetComponent<ObjectDetection>().wallDetected;

                if (wallToDestroy != null)
                    wallToDestroy.GetComponent<WallScroll>().OnDestroyWall();
            }*/
           
        }
    }

    public void ResetRunAnimation() {

        box.offset = new Vector2(0, 0);
        box.size = new Vector2(0.6f, 1.3f);
        box.offset = new Vector2(0, -0.35f);
        

        slideTime = 0;
        anim.SetBool("Running", true);
        anim.SetBool("Sliding", false);

        Debug.Log("Current BoxCollider Size : " + box.size);
    }

	public void OnCollisionEnter2D (Collision2D other) {
        anim.SetBool("Jumping", false);
        anim.SetBool("Running", true);
        
        canJump = true;
        doubleJump = 0;
    }

    
	public void OnCollisionExit2D (Collision2D other) {
        anim.SetBool("Sliding", false);
        anim.SetBool("Running", false);
        //box.size = new Vector2(0.6f, 1.3f);

        canJump = false;
	}
    
    
	public void Jump(){
        anim.SetBool("Sliding", false);
        anim.SetBool("Jumping", true);
        GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpHeight * Time.timeScale); 
    }

}

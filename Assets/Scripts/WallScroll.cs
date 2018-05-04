using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScroll : MonoBehaviour {

    public static float speedUp;
	public float speed;

	// Update is called once per frame
	void FixedUpdate () {
        speedUp += Time.deltaTime;
		gameObject.transform.Translate (new Vector2 (-speed * Time.deltaTime, 0));
        if (speedUp >= 5)
        {
            speedUp = 0;
            speed++;
        }
    }

    public void OnDestroyWall() {
        Destroy(gameObject);
    }
}

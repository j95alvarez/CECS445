using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScroll : MonoBehaviour {

	private float speed = -3f;
	private float start = 0f;
	private int time = 2;

	// Update is called once per frame
	void FixedUpdate () {
		start += Time.deltaTime;
		if (start >= time) {
			speed += .2f;
			start = 0;
		}
		gameObject.transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
	}

    public void OnDestroyWall() {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScroll : MonoBehaviour {

	public static float speed = -3f;
	private float start = 0f;
    private int time = 4;
    private float life = 0;

    // Update is called once per frame
    void FixedUpdate () {
        start += Time.deltaTime;
        life += Time.deltaTime;
        if (start >= time)
        {
            speed -= .05f;
            start = 0f;
        }

		gameObject.transform.Translate (new Vector2 (speed * Time.deltaTime, 0));
	}


}

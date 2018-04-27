using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScroll : MonoBehaviour {
    
	public float speed;

	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.Translate (new Vector2 (-speed * Time.deltaTime, 0));
	}

    public void OnDestroyWall() {
        Destroy(gameObject);
    }
}

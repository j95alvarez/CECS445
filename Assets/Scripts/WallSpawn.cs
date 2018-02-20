using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour {

	public GameObject[] walls;
	private int time = 5;
	private float start = 0;
	public System.Random rand = new System.Random();
	public int wallPick = 3;
	public int wallTypes = 4;

	  
	// Update is called once per frame
	void Update () {
		start += Time.deltaTime;
		if (start >= time) {
			
			if (wallPick == 3) {	
				Instantiate (walls [2], gameObject.transform.position, Quaternion.identity);
				time = 1;
				wallPick = 5;
			}else if(wallPick == 5){
				Instantiate (walls [3], gameObject.transform.position, Quaternion.identity);
				time = rand.Next (1,4);
				wallPick = rand.Next (wallTypes);			
			}else{
				Instantiate (walls [wallPick], gameObject.transform.position, Quaternion.identity);
				time = rand.Next (1,4);
				wallPick = rand.Next (wallTypes);
			}
			start = 0;			

		}
	}
}

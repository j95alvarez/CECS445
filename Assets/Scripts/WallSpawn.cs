using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour {
    public bool startGame;

    [SerializeField]
    private GameObject[] walls;

    [SerializeField]
    private int delayTime;
    private float start = 0;

    // Update is called once per frame
    private void Update () {
		start += Time.deltaTime;
		if (startGame && (start >= delayTime)) {
            start = 0;
            Instantiate(walls[Random.Range(0, walls.Length)], transform.position, Quaternion.identity);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour {

    public bool startGame;
    public float currentSpeed = 0;
    private GameObject wallPick;
    private int mark=4;

    [SerializeField]
    private GameObject[] walls;

    [SerializeField]
    private float delayTime;
    private float start = 0;

    
    // Update is called once per frame
    public void Update ()
    {
        

        start += Time.deltaTime;
		if (startGame && (start >= delayTime)) {
            start = 0;
            
            wallPick = walls[Random.Range(0, walls.Length)];
            var wall = Instantiate(wallPick, transform.position, Quaternion.identity);
            wall.GetComponent<WallScroll>().speed = currentSpeed;
        }
	}

    public void ChangeSpeed(float newSpeed) {
        currentSpeed += newSpeed;
        if (currentSpeed >= mark)
        {
            delayTime -= 0.2f;
            mark += 4;
            System.Console.WriteLine(mark);

        }
    }
}

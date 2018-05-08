using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawn : MonoBehaviour {

    public bool startGame;
    public float currentSpeed = 0;

    [SerializeField]
    private GameObject[] birds;

    [SerializeField]
    private int delayTime;
    private float start = 0;

    // Update is called once per frame
    private void Update()
    {
        start += Time.deltaTime;
        if (startGame && (start >= delayTime))
        {
            start = 0;
            var wall = Instantiate(birds[Random.Range(0, birds.Length)], transform.position, Quaternion.identity);
            wall.GetComponent<WallScroll>().speed = currentSpeed;
        }
    }

    public void ChangeSpeed(float newSpeed)
    {
        currentSpeed += newSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public bool startGame;

    public float speed = 0.05f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            Vector2 offset = new Vector2(Time.time * speed, 0);
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }
    }
}

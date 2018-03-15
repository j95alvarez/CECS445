using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour {

    public GameObject wallDetected;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Wall"))
            wallDetected = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        wallDetected = null;
    }
}

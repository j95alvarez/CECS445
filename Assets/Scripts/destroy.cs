using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collisionObject)
    {
        if (!collisionObject.collider.CompareTag("Untagged"))
            Destroy(collisionObject.gameObject);

    }
}

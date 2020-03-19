using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformCollider : MonoBehaviour
{
    public int forceHeight = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        //Make character jump on hitting the platform
        collision.rigidbody.AddForce(Vector2.up * forceHeight, ForceMode2D.Impulse);
    }
}

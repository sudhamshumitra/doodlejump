using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doodleJump : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Vector3 stageDimensions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

}

// Start is called before the first frame update
void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = Input.acceleration;
        Vector3 position = transform.position;
        Vector3 velocity = rb.velocity;
        //Move based on mobile tilt
        //velocity.x = rb.velocity.x * 2; 
        rb.AddForce(new Vector2 (a.x, 0), ForceMode2D.Impulse);

        //Ensure that when the character is going up, there is no collision
        if (rb.velocity.y >= 0){
            bc.enabled = false;
        } else
        {
            bc.enabled = true;
        }

        //For debugging easily on laptop, have to remove this
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            rb.AddForce(Vector2.right * 2, ForceMode2D.Impulse);
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)){
            rb.AddForce(Vector2.left * 2, ForceMode2D.Impulse);
        }
       
        //To ensure character comes back to screen when moved out of screen
        if (position.x > stageDimensions.x){
            position.x = -stageDimensions.x;
            transform.position = position;

        } else if (position.x < -stageDimensions.x){
            position.x = stageDimensions.x;
            transform.position = position;
        }
    }
}

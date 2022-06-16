using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 2f;
    bool inAir;
    public float speedJump;
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }
    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        //rb.AddForce(moveVector * speed);
    }
    private void Update()
    {
        walk();
        if (Input.GetKey(KeyCode.Space) && !inAir)
        {
            inAir = true;
            rb.velocity = new Vector2(rb.velocity.x, speedJump);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            inAir = false;
    }
}

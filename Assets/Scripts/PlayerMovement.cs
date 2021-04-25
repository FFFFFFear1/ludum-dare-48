using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 50f;

    private Rigidbody2D rb;
    private bool canJump;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // transform.Translate(Vector2.left * speed * Time.deltaTime);
            rb.velocity += Vector2.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // transform.Translate(Vector2.right * speed * Time.deltaTime);
            rb.velocity += Vector2.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(canJump)
                rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
            canJump = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
            canJump = false;
    }
}

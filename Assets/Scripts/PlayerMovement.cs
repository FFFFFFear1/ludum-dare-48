using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    
    
    public float speed = 10f;
    public float jumpForce = 50f;

    private Rigidbody2D rb;
    public bool canJump;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", canJump);
            rb.velocity += Vector2.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", canJump);
            rb.velocity += Vector2.right * speed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("isWalking", false);
            if(canJump)
                rb.Sleep();;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(canJump)
                rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
    
    public void FlipPLayer(bool isFlip)
    {;
        transform.GetComponent<SpriteRenderer>().flipX = !isFlip;
    }
}

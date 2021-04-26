using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    
    
    public float speed = 10f;
    public float jumpForce = 50f;
    public bool canJump;
    public GrappRope grappRope;
    
    private Rigidbody2D rb;
    
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
                rb.Sleep();
            else
            {
                Debug.Log(canJump);
                rb.velocity += Vector2.down * 150 * Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(grappRope.isGrappling)
                rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
    
    public void FlipPLayer(bool isFlip)
    {;
        transform.GetComponent<SpriteRenderer>().flipX = !isFlip;
    }
}

using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int HP = 3;

    public float ultyForce = 2000;
    
    private bool uberJump = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && uberJump)
        {
            uberJump = false;
            transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * ultyForce);
            UIController.instance.UseUlty();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            HP--;
            UIController.instance.TakeDamage(HP);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rat"))
        {
            uberJump = true;
            Destroy(other.gameObject);
            UIController.instance.UseUlty();
        }
    }
}
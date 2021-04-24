using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb;   
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
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
    }
}

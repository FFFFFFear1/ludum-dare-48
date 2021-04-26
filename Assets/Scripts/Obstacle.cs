using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    private void Start()
    {
        transform.Rotate(new Vector3(0,0,Random.Range(0,180)));
        transform.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.down * 500000 * Time.deltaTime);
    }
}
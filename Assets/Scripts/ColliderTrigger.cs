using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderTrigger : MonoBehaviour
{
    public BoxCollider2D bc;

    public void Awake()
    {
        bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("End");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullat : MonoBehaviour
{
    float speed = 10;
    public Rigidbody2D r2D;

    private void Start()
    {
        r2D.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
            gameObject.SetActive(false);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "wall")
            gameObject.SetActive(false);
        if (collision.gameObject.tag == "Enemy")
            gameObject.SetActive(false);
    }
}

  

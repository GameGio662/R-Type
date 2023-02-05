using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed = 3;

    public Rigidbody2D r2D;

    private void Start()
    {
        r2D = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        r2D.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boom")
            gameObject.SetActive(false);
    }
}

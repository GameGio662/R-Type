using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BulletEnemy : MonoBehaviour
{
    MyPlayer mP;
    public float speed = 10;
    EffectPowerUp ePU;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mP = FindObjectOfType<MyPlayer>();
        ePU = FindObjectOfType<EffectPowerUp>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(-10 * speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boom")
            Destroy(gameObject);

        if (collision.gameObject.tag == "wall")
            Destroy(gameObject);

        if (collision.CompareTag("Player"))
        {
            if (ePU.nonToccarmi == false)
            {
                mP.hitCount = 1;
                mP.health -= 50;
            }
            Destroy(gameObject);
        }
    }


}

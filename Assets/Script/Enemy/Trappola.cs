using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trappola : MonoBehaviour
{
    float time;

    EffectPowerUp ePU;
    MyPlayer mP;
    GameManager GM;

    private void Start()
    {
        ePU = FindObjectOfType<EffectPowerUp>();
        mP = FindObjectOfType<MyPlayer>();
        GM = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
            TimeMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ePU.nonToccarmi == false)
            {
                mP.hitCount = 1;
                mP.health -= 50;
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "wall")
            Destroy(gameObject);

        if (collision.gameObject.tag == "floor")
            Destroy(gameObject);
    }

    void TimeMove()
    {
        if(time <= 1) 
        {
            transform.Translate(Vector2.zero);
            time += 1 * Time.deltaTime;
        }

        if(time >= 1)
        {
            transform.Translate(new Vector2(0, -5 * Time.deltaTime));
        }
    }
}

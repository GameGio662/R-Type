using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    float time, timeMove;
    bool stop = true;
    int random;

    [SerializeField] GameObject BulletEnemy, fire;

    EffectPowerUp ePU;
    MyPlayer mP;
    GameManager GM;

    void Start()
    {
        random = Random.Range(4, 7);
        timeMove = 1;
        ePU = FindObjectOfType<EffectPowerUp>();
        mP = FindObjectOfType<MyPlayer>();
        GM = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
        {
            Shoot();
            MoveEnemy3();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ePU.nonToccarmi == false)
            {
                mP.hitCount = 1;
                mP.health -= 50;
            }
            Destroy(gameObject);
        }
            if (collision.gameObject.tag == "Bullet")
                Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boom"))
            Destroy(gameObject);
    }

    private void Shoot()
    {
        time += 1 * Time.deltaTime;
        if (time >= random)
        {
            GameObject myBullet = Instantiate(BulletEnemy);
            myBullet.transform.position = fire.transform.position;
            myBullet.transform.rotation = fire.transform.rotation;
            time = 0;
        }
    }

    private void MoveEnemy3()
    {
        if (timeMove >= 0 && stop == false)
        {
            transform.Translate(new Vector2(-1 * Time.deltaTime, 5 * Time.deltaTime));
            timeMove += 1 * Time.deltaTime;
            if (timeMove >= 1.5)
            {
                timeMove = 1.5f;
                stop = true;
            }
        }

        if (timeMove <= 1.5 && stop == true)
        {
            transform.Translate(new Vector2(-1 * Time.deltaTime, -5 * Time.deltaTime));
            timeMove -= 1 * Time.deltaTime;
            if (timeMove <= 0)
            {
                timeMove = 0;
                stop = false;
            }
        }


    }
}

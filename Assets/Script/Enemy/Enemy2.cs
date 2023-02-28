using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    float time;
    int vita = 2;

    [SerializeField] GameObject BulletEnemy;
    [SerializeField] GameObject fire;
    [SerializeField] GameObject shieldEnemy;

    EffectPowerUp ePU;
    MyPlayer mP;
    UIManager UI;
    TimeManager tM;
    GameManager GM;
    private void Start()
    {
        ePU = FindObjectOfType<EffectPowerUp>();
        mP = FindObjectOfType<MyPlayer>();
        UI = FindObjectOfType<UIManager>();
        tM = FindObjectOfType<TimeManager>();
        GM = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
        {
            Shoot();
            VitaRimanente();
            if (tM.endWave == true)
                Destroy(gameObject);
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
        if (collision.gameObject.tag == "wall")
            Destroy(gameObject);
        if (collision.gameObject.tag == "Bullet")
            vita--;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boom"))
            Destroy(gameObject);
    }

    public void Shoot()
    {
        time += 1 * Time.deltaTime;
        if (time >= 2)
        {
            GameObject myBullet = Instantiate(BulletEnemy);
            myBullet.transform.position = fire.transform.position;
            myBullet.transform.rotation = fire.transform.rotation;
            time = 0;
        }
    }

    private void VitaRimanente()
    {
        if (vita == 1)
            shieldEnemy.SetActive(false);
        if (vita == 0)
        {
            Destroy(gameObject);
            UI.enemyPunt += 50;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    [Header("Stats player")]
    [SerializeField] public int health = 150;
    [HideInInspector] public int hitCount;
    [HideInInspector] public float distancePlayer;

    [Header("Comandi")]
    float horizontalInput, verticalInput;
    public float speedMovement;
    //float charge;

    [Header("Timer")]
    private float TimeShoot;

    [Header("Obj")]
    [SerializeField] GameObject Fire;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Respawn;



    [SerializeField] public Transform Player;
    [HideInInspector] public Rigidbody2D rb;

    [Header("other.scrip")]
    EffectPowerUp ePU;
    UIManager UI;
    GameManager GM;



    void Start()
    {
        ePU = FindObjectOfType<EffectPowerUp>();
        rb = GetComponent<Rigidbody2D>();
        UI = FindObjectOfType<UIManager>();
        GM = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
        {
            DeathPlayaer();
            MyInput();
            Shoot();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontalInput * speedMovement, verticalInput * speedMovement);

    }

    public void DeathPlayaer()
    {
        if (hitCount == 1)
        {
            UI.Hpcount++;
            gameObject.transform.position = Respawn.transform.position;
            ePU.nonToccarmi = true;
            hitCount--;
        }
        if (health == 0)
        {
            gameObject.SetActive(false);
            UI.EndCanvas.SetActive(true);
            GM.EndGame();
        }

    }


    public void Shoot()
    {
        if (TimeShoot <= 1)
            TimeShoot += 1 * Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && TimeShoot >= 1 || Input.GetKeyDown("j") && TimeShoot >= 1)
        {
            GameObject myBullet = Instantiate(Bullet);
            myBullet.transform.position = Fire.transform.position;
            myBullet.transform.rotation = Fire.transform.rotation;
            TimeShoot = 0;
        }

        //if (Input.GetButton("Fire2") && charge <= 3)
        //{
        //    charge += 1 * Time.deltaTime;
        //    Debug.Log(charge);
        //    if (charge >= 3)
        //    {
        //        GameObject myBullet = Instantiate(bullet);
        //        myBullet.transform.position = gameObject.transform.position;
        //        myBullet.transform.rotation = gameObject.transform.rotation;
        //        charge = 0;
        //    }
        //}
        //else if (charge < 3)
        //{
        //    charge = 0;
        //}

    }

    public void JumpEnemy()
    {
        distancePlayer = gameObject.transform.position.x + transform.position.x;

    }
}

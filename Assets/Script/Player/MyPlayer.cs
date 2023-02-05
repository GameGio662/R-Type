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
    [SerializeField] Transform Player;
    [HideInInspector] public Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        DeathPlayaer();
        MyInput();
        Shoot();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontalInput * speedMovement, verticalInput * speedMovement);

    }

    public void DeathPlayaer()
    {
        if(health > 0)
        {
            if(hitCount == 1)
            {
                hitCount--;
                gameObject.transform.position = Respawn.transform.position;
            }
        }
        else
        {
                gameObject.SetActive(false);
        }
        
    }


    public void Shoot()
    {
        if (TimeShoot <= 1)
            TimeShoot += 1 * Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && TimeShoot >= 1)
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

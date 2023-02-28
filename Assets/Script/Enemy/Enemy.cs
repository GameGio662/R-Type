using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Ground")]
    [SerializeField] float moveSpeed, circleRadius;
    private float moveDirection = -1;
    private bool checkingGround, checkingWall;
    [SerializeField] Transform groundCheckPoint, wallCheckPoint;
    [SerializeField] LayerMask groundLayer;


    [Header("jump")]
    [SerializeField] float jumpHaight;
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 boxSize;
    private bool isGrounded;


    [Header("Attack")]
    [SerializeField] Vector2 lineOfSite;
    [SerializeField] LayerMask PlayerLayer;
    private bool cannSeePlayer;
    private float time, timejump;


    [Header("Shoot")]
    [SerializeField] GameObject BulletEnemy;
    [SerializeField] GameObject fire;

    TimeManager tM;
    MyPlayer mP;
    UIManager UI;
    EffectPowerUp ePU;
    GameManager GM;
    Rigidbody2D rb;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        UI = FindObjectOfType<UIManager>();
        mP = FindObjectOfType<MyPlayer>();
        rb = GetComponent<Rigidbody2D>();
        ePU = FindObjectOfType<EffectPowerUp>();
        tM = FindObjectOfType<TimeManager>();
    }

    private void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
        {
            Physics();
            TimerShoot();
            TimerJump();
            Petrolling();
            if (tM.endWave == true)
                Destroy(gameObject);

        }
    }

    private void Physics()
    {
        checkingGround = Physics2D.OverlapCircle(groundCheckPoint.position, circleRadius, groundLayer);
        checkingWall = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, groundLayer);
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        cannSeePlayer = Physics2D.OverlapBox(transform.position, lineOfSite, 0, PlayerLayer);
    }
    void JumpAttack()
    {
        if (isGrounded)
            rb.AddForce(new Vector2(-5 * Time.deltaTime, jumpHaight * Time.deltaTime));
    }

    void Petrolling()
    {
        if (isGrounded)
            rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boom"))
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (ePU.nonToccarmi == false)
            {
                mP.hitCount = 1;
                mP.health -= 50;
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            UI.enemyPunt += 50;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheckPoint.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheckPoint.position, circleRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawCube(groundCheck.position, boxSize);
        Gizmos.DrawWireCube(transform.position, lineOfSite);

    }

    public void Shoot()
    {
        GameObject myBullet = Instantiate(BulletEnemy);
        myBullet.transform.position = fire.transform.position;
        myBullet.transform.rotation = fire.transform.rotation;
    }

    private void TimerShoot()
    {
        if (time <= 1)
            time += 1 * Time.deltaTime;

        if (time >= 1)
        {
            if (cannSeePlayer)
            {
                Shoot();
                time = 0;
            }
        }
    }

    private void TimerJump()
    {
        if (timejump <= 2)
            timejump += 1 * Time.deltaTime;

        if (timejump >= 2 || checkingWall)
        {
            JumpAttack();
            timejump = 0;
        }
    }
}

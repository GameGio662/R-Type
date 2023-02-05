using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    MyPlayer mP;

    [Header("Ground")]
    [SerializeField] float moveSpeed, circleRadius;
    private float moveDirection = -1;
    private bool checkingGround, checkingWall;
    [SerializeField] Transform groundCheckPoint, wallCheckPoint;
    [SerializeField] LayerMask groundLayer;
    Rigidbody2D rb;

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
    
    private void Start()
    {
        mP = FindObjectOfType<MyPlayer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        checkingGround = Physics2D.OverlapCircle(groundCheckPoint.position, circleRadius, groundLayer);
        checkingWall = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, groundLayer);
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        cannSeePlayer = Physics2D.OverlapBox(transform.position, lineOfSite, 0, PlayerLayer);
        TimerShoot();
        TimerJump();
        Petrolling();
        
    }

    void JumpAttack()
    {
        if (isGrounded && checkingWall)
            rb.AddForce(new Vector2(mP.distancePlayer, jumpHaight * Time.deltaTime), ForceMode2D.Impulse);
    }

    void Petrolling()
    {
        if (isGrounded)
            rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boom"))
            gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mP.hitCount = 1;
            mP.health -= 50;
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Bullet")
            gameObject.SetActive(false);   
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
        if (time <= 3)
            time += 1 * Time.deltaTime;

        if (time >= 3)
        {
            Shoot();
            time = 0;
        }
    }

    private void TimerJump()
    {
        if (timejump <= 2)
            timejump += 1 * Time.deltaTime;

        if (timejump >= 2)
        {
            JumpAttack();
            timejump = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Spawn : MonoBehaviour
{
    [SerializeField] GameObject Enemy3;
    [SerializeField] GameObject Trappola;
    [SerializeField] GameObject Player;
    [SerializeField] Transform Up, Down, left, right;
    float Uplimite, Downlimite, Leftlimite, Rightlimite, random, time, timers;

    GameManager GM;

    void Start()
    {
        random = Random.Range(7, 9);
        Uplimite = Up.transform.position.y;
        Downlimite = Down.transform.position.y;
        Leftlimite = Down.transform.position.x;
        Rightlimite = Down.transform.position.x;
        GM = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
        {
            TimeSpawnEnemy3();
            TimeSpawnTrap();
        }
    }

    private void TimeSpawnEnemy3()
    {
        time += 1 * Time.deltaTime;

        if (time >= 8)
        {
            GameObject enemy3 = Instantiate(Enemy3);
            enemy3.transform.position = SpawnPositionFront();
            time = 0;
        }
    }

    private void TimeSpawnTrap()
    {
        timers += 1 * Time.deltaTime;

        if (timers >= random)
        {
            GameObject trappola = Instantiate(Trappola);
            trappola.transform.position = SpawnPositionUp();
            timers = 0;
        }
    }

    private Vector2 SpawnPositionFront()
    {
        return new Vector2(transform.position.x, Random.Range(Uplimite, Downlimite));
    }

    private Vector2 SpawnPositionUp()
    {
        return new Vector2(Player.transform.position.x, Random.Range(Leftlimite, Rightlimite));
    }
}

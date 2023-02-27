using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy2 : MonoBehaviour
{
    float time;

    [SerializeField] GameObject Enemy2;
    [SerializeField] Transform Up, Down;
    float Uplimite, Downlimite;

    GameManager GM;

    void Start()
    {
        time = 7f;
        Uplimite = Up.transform.position.y;
        Downlimite = Down.transform.position.y;
        GM = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
            TimeSpawn();
    }

    private void TimeSpawn()
    {
        time += 1 * Time.deltaTime;

        if(time >= 6f)
        {
            GameObject enemy2 = Instantiate(Enemy2);
            enemy2.transform.position = SpawnPosition();
            time = 0;
        }
    }

    private Vector2 SpawnPosition()
    {
        return new Vector2(transform.position.x, Random.Range(Uplimite, Downlimite));
    }
}

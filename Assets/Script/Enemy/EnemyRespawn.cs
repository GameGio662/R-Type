using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    [Header("Obj")]
    [SerializeField]
    GameObject Enemy1;

    [Header("timer")]
    public float timer = 2.5f;

    TimeManager tM;

    private void Start()
    {
        tM = FindObjectOfType<TimeManager>();
    }

    private void Update()
    {
        if(tM.stopTime == false)
        {
        SpawnTimer();
        Spawn();
        }
    }

    public void Spawn()
    {
        if (timer <= 0 )
        {
            GameObject enemy1 = Instantiate(Enemy1);
            enemy1.transform.position = gameObject.transform.position;
            timer = 2.5f;
        }
    }

    public void SpawnTimer()
    {
        if (timer > 0)
            timer -= 1 * Time.deltaTime;
    }
}

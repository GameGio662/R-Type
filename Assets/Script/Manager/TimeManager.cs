using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float time;
    bool nextWave = false;

    [SerializeField] GameObject spawn1;

    GameManager GM;
    UIManager UI;

    void Start()
    {
        time = 65;
        GM = FindObjectOfType<GameManager>();
        UI = FindObjectOfType<UIManager>();
    }


    void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
        {
            Timer();
            TimerForNextWave();
        }
    }

    private void Timer()
    {
        if (nextWave == false)
        {
            if (time > 0)
                time -= 1 * Time.deltaTime;
            if (time <= 5)
                spawn1.SetActive(false);
            if (time <= 0)
            {
                nextWave = true;
                time = 15;
            }
        }

    }

    private void TimerForNextWave()
    {
        if (nextWave == true && time > 0)
        {
            time -= 1 * Time.deltaTime;
            if (time <= 0)
            {

            }
        }


    }

}

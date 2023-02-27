using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float time, timeNextWave;
    bool Wave1, Wave2, Wave3, timeStop;
    public bool hp;
    [HideInInspector] public bool endWave;

    [SerializeField] GameObject spawn1;
    [SerializeField] GameObject spawn2;
    [SerializeField] GameObject spawn3;
    [SerializeField] GameObject TextWave;
    [SerializeField] GameObject TimerText;
    [SerializeField] GameObject AvvisoText;
    [SerializeField] GameObject End;

    MyPlayer mP;
    GameManager GM;

    void Start()
    {
        time = 65;
        GM = FindObjectOfType<GameManager>();
        mP = FindObjectOfType<MyPlayer>();
    }


    void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
        {
            TimerForNextWave();
            TimerWave1();
            TimerWave2();
            TimerWave3();
        }

    }

    private void TimerWave1()
    {
        if (Wave1 == false)
        {
            if (time > 0)
                time -= 1 * Time.deltaTime;

            if (time <= 10)
            {
                spawn1.SetActive(false);
                endWave = true;
            }

            if (time <= 0)
            {
                Wave1 = true;
                timeStop = true;
                timeNextWave = 15;
            }
        }

    }

    private void TimerForNextWave()
    {
        if (timeStop == true)
        {
            mP.health = 150;
            hp = true;
            timeNextWave -= 1 * Time.deltaTime;
            TextWave.SetActive(true);
            TimerText.SetActive(true);

            if (timeNextWave <= 0)
            {
                hp = false;
                TimerText.SetActive(false);
                TextWave.SetActive(false);
                timeStop = false;
                time = 65;
            }
        }
    }

    private void TimerWave2()
    {
        if (Wave1 == true && Wave2 == false)
        {
            if (time > 0)
            {
                time -= 1 * Time.deltaTime;
                spawn2.SetActive(true);
                endWave = false;


                if (time <= 15)
                {
                    spawn2.SetActive(false);
                }

                if (time <= 0)
                {
                    Wave2 = true;
                    timeStop = true;
                    timeNextWave = 15;
                    AvvisoText.SetActive(true);
                }
            }
        }
    }

    private void TimerWave3()
    {
        if (Wave1 == true && Wave2 == true && Wave3 == false)
        {
            if (time > 0)
            {
                time -= 1 * Time.deltaTime;
                spawn3.SetActive(true);
                AvvisoText.SetActive(false);
                endWave = false;


                if (time <= 10)
                {
                    spawn3.SetActive(false);
                    endWave = true;
                }

                if (time <= 0)
                {
                    GM.EndGame();
                    End.SetActive(true);
                }
            }
        }
    }
}

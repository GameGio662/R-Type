using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float time, timeNextWave;
    bool Wave1, Wave2 = false;
    bool timeStop;
    [HideInInspector] public bool endWave;

    [SerializeField] GameObject spawn1;
    [SerializeField] GameObject spawn2;
    [SerializeField] GameObject TextWave;
    [SerializeField] GameObject TimerText;


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
            TimerWave1();
            TimerForNextWave();
            TimerWave2();
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
                timeStop= true;
                timeNextWave = 15;
                TextWave.SetActive(true);
                TimerText.SetActive(true);
            }
        }

    }

    private void TimerForNextWave()
    {
        if (timeStop == true)
        {
            timeNextWave -= 1 * Time.deltaTime;
            if (timeNextWave <= 0)
            {
                TextWave.SetActive(false);
                TimerText.SetActive(false);
                time = 65;
                Wave2 = true;
                timeStop = false;
            }
        }
    }

    private void TimerWave2()
    {
        if (Wave2 == true)
        {
            time -= 1 * Time.deltaTime;
            Debug.Log(time);
            spawn2.SetActive(true);
            endWave = false;


            if (time <= 10)
            {
                spawn2.SetActive(false);
                endWave = true;
            }

            if (time <= 0)
            {
                TextWave.SetActive(true);
                Wave2 = false;
                timeNextWave = 15;
            }
        }
    }
}

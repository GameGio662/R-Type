using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float time;

    GameManager GM;
    UIManager UI;

    void Start()
    {
        time = 50;
        GM = FindObjectOfType<GameManager>();
        UI = FindObjectOfType<UIManager>();
    }


    void Update()
    {
        if (GM.gameStatus == GameManager.GameStatus.gameRunning)
            Timer();
    }

    private void Timer()
    {
            if (time > 0)
                time -= 1 * Time.deltaTime;

            if (time <= 0)
            {
                UI.LevelCanvas.SetActive(true);
                GM.EndGame();
            }
    }

}

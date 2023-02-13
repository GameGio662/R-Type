using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIManager UM;

    public enum GameStatus
    {
        gamePaused,
        gameRunning,
        gameEnd,
        gameStart,
    }

    public GameStatus gameStatus = GameStatus.gameRunning;

    private void Update()
    {
        if (UM == null)
            UM = FindObjectOfType<UIManager>();

        if (Input.GetKeyDown("escape") && gameStatus == GameStatus.gameRunning)
        {
            gameStatus = GameStatus.gamePaused;
            UM.pauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown("escape") && gameStatus == GameStatus.gamePaused)
        {
            gameStatus = GameStatus.gameRunning;
            UM.pauseMenu.SetActive(false);
        }
    }

    public void EndGame()
    {
        gameStatus = GameStatus.gameEnd;
    }
}

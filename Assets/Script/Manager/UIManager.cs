using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [HideInInspector] public int enemyPunt, Hpcount;

    [SerializeField] GameObject Hp3;
    [SerializeField] GameObject Hp2;
    [SerializeField] GameObject Hp1;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI ScoreToT;
    [SerializeField] TextMeshProUGUI Time;
    [SerializeField] public TextMeshProUGUI TimerText;
    [SerializeField] public GameObject startCanvas;
    [SerializeField] public GameObject TutorialCanvas;
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject EndCanvas;
    [SerializeField] public GameObject LevelCanvas;

    GameManager GM;
    TimeManager tM;

    private void Start()
    {
        tM = FindObjectOfType<TimeManager>();
        GM = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Hpcount == 1)
            Hp3.SetActive(false);
        else if (Hpcount == 2)
            Hp2.SetActive(false);
        else if (Hpcount == 3)
            Hp1.SetActive(false);

        Score.text = enemyPunt.ToString("0000");
        ScoreToT.text = enemyPunt.ToString("0000");
        Time.text = tM.time.ToString("00");
        TimerText.text = tM.timeNextWave.ToString("00");

    }

    public void Play()
    {
        startCanvas.SetActive(false);
        GM.gameStatus = GameManager.GameStatus.gameRunning;
    }

    public void Tutorial()
    {
        TutorialCanvas.SetActive(true);
        startCanvas.SetActive(false);
    }

    public void Continue()
    {
        GM.gameStatus = GameManager.GameStatus.gameRunning;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        GM.gameStatus = GameManager.GameStatus.gamePaused;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [HideInInspector] public int enemyPunt, Hpcount;


    [SerializeField] GameObject Hp3;
    [SerializeField] GameObject Hp2;
    [SerializeField] GameObject Hp1;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI Time;

    TimeManager tM;

    private void Start()
    {
        tM = FindObjectOfType<TimeManager>();
    }

    private void Update()
    {
        if (Hpcount == 1)
            Hp3.SetActive(false);
        else if (Hpcount == 2)
            Hp2.SetActive(false);
        else if (Hpcount == 3)
            Hp1.SetActive(false);
        Debug.Log(Hpcount);

        Score.text = enemyPunt.ToString("0000");
        Time.text = tM.time.ToString("00");

    }



}

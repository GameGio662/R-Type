using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float cooldown = 60;
    float time;
    bool stopTime = false;

    void Start()
    {
        time = cooldown;
    }


    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        if (stopTime == false)
        {
            if (time > 0)
                time -= 1 * Time.deltaTime;

            if (time <= 0)
            {
                Debug.Log("sono gay");
                time = 0;
                stopTime = true;

            }
        }


    }

}

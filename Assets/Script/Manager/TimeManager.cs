using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float cooldown = 50;
    public float time;
   [HideInInspector] public bool stopTime = false;

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
                time = 0;
                stopTime = true;
            }
        }


    }

}

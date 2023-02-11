using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScenario : MonoBehaviour
{

    float timer;
    bool stopTimer = false;
    float speedCamera = 1;
    Rigidbody2D rb;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

   
    void Update()
    {
        StartTimer();
    }


   public void StartTimer()
    {
        if (stopTimer == false)
        {
            if (timer < 3)
                timer += 1 * Time.deltaTime;
        }
            if(timer >= 3)
            {
              transform.Translate(new Vector2(1 * speedCamera * Time.deltaTime, 0));
             stopTimer = true;
             timer = 4;
            }

                         
        
    }

    
}

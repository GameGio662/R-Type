using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPowerUp : MonoBehaviour
{
    float timer;
    public bool nonToccarmi = false;

    private void Update()
    {
        TimerInvincibilitā();
    }

   public void TimerInvincibilitā()
    {
        if(nonToccarmi == true) 
        {
           if (timer <= 2)
              timer += 1 * Time.deltaTime;
           else if (timer >= 2)
          {
              timer = 0;
              nonToccarmi = false;
           }
        }
    }
}

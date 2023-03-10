using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPowerUp : MonoBehaviour
{
    float timer;
    [HideInInspector] public bool nonToccarmi = false;

    [SerializeField] public GameObject Invulnerabilitā;

    private void Update()
    {
        TimerInvincibilitā();
    }

    public void TimerInvincibilitā()
    {
        if (nonToccarmi == true)
        {
            if (timer <= 2)
            {
                timer += 1 * Time.deltaTime;
                Invulnerabilitā.SetActive(true);
            }
            else if (timer >= 2)
            {
                timer = 0;
                nonToccarmi = false;
                Invulnerabilitā.SetActive(false);
            }
        }
    }
}

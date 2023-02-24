using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPowerUp : MonoBehaviour
{
    float timer;
    [HideInInspector] public bool nonToccarmi = false;

    [SerializeField] public GameObject Invulnerabilit�;

    private void Update()
    {
        TimerInvincibilit�();
    }

    public void TimerInvincibilit�()
    {
        if (nonToccarmi == true)
        {
            if (timer <= 2)
            {
                timer += 1 * Time.deltaTime;
                Invulnerabilit�.SetActive(true);
            }
            else if (timer >= 2)
            {
                timer = 0;
                nonToccarmi = false;
                Invulnerabilit�.SetActive(false);
            }
        }
    }
}

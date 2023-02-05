using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethOffCamFront : MonoBehaviour
{
    MyPlayer mP;
    EffectPowerUp ePU;
    private void Start()
    {
        mP = FindObjectOfType<MyPlayer>();
        ePU = FindObjectOfType<EffectPowerUp>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ePU.nonToccarmi == false)
        {
            mP.hitCount = 1;
            mP.health -= 50;
        }
    }
}

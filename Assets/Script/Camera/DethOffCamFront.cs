using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethOffCamFront : MonoBehaviour
{
    MyPlayer mP;
    private void Start()
    {
        mP = FindObjectOfType<MyPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mP.hitCount = 1;
            mP.health -= 50;
        }

    }
}

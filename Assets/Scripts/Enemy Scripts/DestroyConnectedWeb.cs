using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyConnectedWeb : MonoBehaviour
{

    public EnemyHealth enemyHealth;
    private bool destroyed = false;

    void Update()
    {
        if (enemyHealth.currHp <= 0 && !destroyed)
        {
            destroyed = true;
            gameObject.GetComponent<Pendulum>().enabled = false;
        }
    }
}

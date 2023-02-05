using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHp;
    public int currHp;

    void Start()
    {
        currHp = maxHp;
    }

    public void takeDamage(int damage)
    {
            currHp -= damage;
            if (currHp <= 0)
            {
                killEnemy();
            }
    }

    void killEnemy()
    {
        Destroy(gameObject);
    }
}

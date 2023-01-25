using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
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
        if(currHp <= 0)
        {
            killPlayer();
        }
    }

    void killPlayer()
    {
        Debug.Log("U R DEAD");
        // STUFF
    }
}

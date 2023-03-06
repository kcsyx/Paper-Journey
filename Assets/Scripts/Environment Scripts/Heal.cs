using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(playerHealth.currHp < playerHealth.maxHp)
            {
                playerHealth.currHp += 1;
                Destroy(gameObject);
            }
        }
    }
}

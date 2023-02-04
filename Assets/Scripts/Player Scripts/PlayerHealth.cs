using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public SpriteRenderer sprite;
    public PlayerMovement playerMovement;

    public int maxHp;
    public int currHp;

    public bool canTakeDamage;
    public int flickerAmt;
    public float flickerDuration;

    void Start()
    {
        currHp = maxHp;
        canTakeDamage = true;
    }

    public void takeDamage(int damage)
    {
        if(canTakeDamage == true)
        {
            currHp -= damage;
            if (currHp <= 0)
            {
                killPlayer();
            }

            StartCoroutine(DamageFlicker());
        }
    }

    void killPlayer()
    {
        sprite.enabled = false;
        playerMovement.enabled = false;
    }

    IEnumerator DamageFlicker()
    {
        canTakeDamage = false;
        for(int i = 0; i < flickerAmt; i++)
        {
            sprite.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(flickerDuration);
            sprite.color = Color.white;
            yield return new WaitForSeconds(flickerDuration);
            canTakeDamage = true;
        }
    }
}
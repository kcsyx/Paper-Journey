using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public SpriteRenderer sprite;
    public PlayerMovement playerMovement;
    public PlayerRespawn playerRespawn;
    public Shoot playerShoot;

    public GameObject deathMenu;

    static public int maxHp = 3;
    static public int currHp = maxHp;
    
    public bool canTakeDamage;
    public int flickerAmt;
    public float flickerDuration;

    void Start()
    {
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
        deathMenu.SetActive(true);
        sprite.enabled = false;
        playerRespawn.enabled = false;
        playerMovement.enabled = false;
        playerShoot.enabled = false;
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
        }
        yield return new WaitForSeconds(1);
        canTakeDamage = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public SpriteRenderer sprite;

    public int maxHp;
    public int currHp;
    public int flickerAmt;
    public float flickerDuration;

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
            StartCoroutine(DamageFlicker());
    }

    void killEnemy()
    {
        Destroy(gameObject);
    }

    IEnumerator DamageFlicker()
    {
        for (int i = 0; i < flickerAmt; i++)
        {
            sprite.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(flickerDuration);
            sprite.color = Color.red;
            yield return new WaitForSeconds(flickerDuration);
        }
    }
}
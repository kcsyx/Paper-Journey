using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public SpriteRenderer sprite;
    public ParticleSystem deathParticle;

    private EnemyDamage enemyDamage;
    private SpriteRenderer enemySprite;
    private Collider2D enemyCollider;

    public int maxHp;
    public int currHp;
    public int flickerAmt;
    public float flickerDuration;

    void Start()
    {
        enemyCollider = GetComponent<Collider2D>();
        enemyDamage = GetComponent<EnemyDamage>();
        enemySprite = GetComponent<SpriteRenderer>();
        currHp = maxHp;
    }

    public void takeDamage(int damage)
    {
        currHp -= damage;
        
        if (currHp <= 0)
        {
            AudioManager.instance.PlaySFX("enemy_die");
            enemyDamage.enabled = false;
            enemyCollider.enabled = false;
            enemySprite.enabled = false;
            killEnemy();
        }

        else
        {
            AudioManager.instance.PlaySFX("enemy_hurt");
        }
       
        StartCoroutine(DamageFlicker());
    }

    void killEnemy()
    {
        StartCoroutine(Death());
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

    IEnumerator Death()
    {
        deathParticle.Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

}

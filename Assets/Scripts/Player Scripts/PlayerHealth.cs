using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public SpriteRenderer sprite;
    public PlayerMovement playerMovement;
    public PlayerRespawn playerRespawn;
    public Shoot playerShoot;

    private Rigidbody2D playerRb;
    private ParticleController playerParticles;
    /*private Collider2D[] playerColliders;*/
    public ParticleSystem deathParticle;
    public GameObject deathMenu;

    static public int maxHp = 3;
    static public int currHp = maxHp;
    
    public bool canTakeDamage;
    public int flickerAmt;
    public float flickerDuration;

    void Start()
    {
        canTakeDamage = true;
        playerRb = GetComponent<Rigidbody2D>();
        playerParticles = GetComponentInChildren<ParticleController>();
        /*playerColliders = GetComponents<Collider2D>();*/
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
            AudioManager.instance.PlaySFX("dmg");
        }
    }

    void killPlayer()
    {
        playerRb.bodyType = RigidbodyType2D.Static;
        sprite.enabled = false;
        /*        for (int i = 0; i < playerColliders.Length; i++)
                {
                    playerColliders[i].enabled = false;
                };*/
        playerParticles.enabled = false;
        playerRespawn.enabled = false;
        playerMovement.enabled = false;
        playerShoot.enabled = false;

        StartCoroutine(Death());
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

    IEnumerator Death()
    {
        deathParticle.Play();
        yield return new WaitForSeconds(1f);
        deathMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}

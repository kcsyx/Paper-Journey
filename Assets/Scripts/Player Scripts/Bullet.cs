using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody2D rb;
    public int bulletDamage = 1;
    Collider2D bulletCollider;
    public bool IsPlatformOrNot = false;

    public Shoot playerShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        bulletCollider = GetComponent<Collider2D>();
        bulletCollider.isTrigger = true;
    }

    void Update()
    {
        StartCoroutine(DestroyBullet());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            if (collision.tag == "Wall")
            {

                if (playerShoot.platformsSpawned == 0 || playerShoot.platformsSpawned == 1)
                {
                    bulletCollider.isTrigger = false;
                    IsPlatformOrNot = true;
                    gameObject.layer = LayerMask.NameToLayer("Ground");
                    playerShoot.platformsSpawned++;
                    playerShoot.bullets.Add(gameObject);
                    rb.bodyType = RigidbodyType2D.Static;
                    return;
                } else
                {
                    Destroy(playerShoot.bullets[0]);
                    playerShoot.bullets.RemoveAt(0);
                    playerShoot.platformsSpawned--;
                    bulletCollider.isTrigger = false;
                    IsPlatformOrNot = true;
                    gameObject.layer = LayerMask.NameToLayer("Ground");
                    playerShoot.platformsSpawned++;
                    playerShoot.bullets.Add(gameObject);
                    rb.bodyType = RigidbodyType2D.Static;
                    return;
                }
            }
            else if (collision.tag == "Hinge_Wall")
            {
                collision.attachedRigidbody.bodyType = RigidbodyType2D.Dynamic;
                collision.attachedRigidbody.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
            } else if (collision.tag == "Checkpoint" || collision.tag == "ZoomOut" || collision.tag == "ZoomIn" || collision.tag == "Goal")
            {
                return;
            }
            else if (collision.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyHealth>().takeDamage(bulletDamage);
            }
            else if (collision.tag == "Bullet")
            {
                Destroy(gameObject);
                return;
            }
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1);
        if(!IsPlatformOrNot)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody2D rb;
    public GameObject bulletPlatformPrefab;
    public int bulletDamage = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            if (collision.tag == "Wall")
            {
                Instantiate(bulletPlatformPrefab, transform.position, transform.rotation);
            }
            else if (collision.tag == "Hinge_Wall")
            {
                collision.attachedRigidbody.bodyType = RigidbodyType2D.Dynamic;
                collision.attachedRigidbody.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
            } else if (collision.tag == "Checkpoint")
            {
                return;
            }
            else if (collision.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyHealth>().takeDamage(bulletDamage);
            }
            Destroy(gameObject);
        }
    }
}

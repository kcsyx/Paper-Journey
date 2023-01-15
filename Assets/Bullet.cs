using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody2D rb;
    public GameObject bulletPlatformPrefab;

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
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletDrip : MonoBehaviour
{
    private float speed = 6f;
    private Rigidbody2D rb;
    public int dropletDamage = 1;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, -speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(dropletDamage);
            audioSource.Play();
        }

        if(collision.tag == "Ground")
        {
            audioSource.Play();
        }
        Destroy(gameObject);
    }
}

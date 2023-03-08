using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbtackBox : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerHealth>().canTakeDamage)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 20f, ForceMode2D.Impulse);
            }
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(damage);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerHealth>().canTakeDamage)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 20f, ForceMode2D.Impulse);
            }
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(damage);
        }
    }
}

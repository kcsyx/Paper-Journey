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
            if (collision.gameObject.transform.parent.gameObject.GetComponent<PlayerHealth>().canTakeDamage)
            {
                collision.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 10f, ForceMode2D.Impulse);
            }
            collision.gameObject.transform.parent.gameObject.GetComponent<PlayerHealth>().takeDamage(damage);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.gameObject.transform.parent.gameObject.GetComponent<PlayerHealth>().canTakeDamage)
            {
                collision.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 10f, ForceMode2D.Impulse);
            }
            collision.gameObject.transform.parent.gameObject.GetComponent<PlayerHealth>().takeDamage(damage);
        }
    }
}

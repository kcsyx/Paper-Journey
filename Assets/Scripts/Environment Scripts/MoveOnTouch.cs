using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{

    //Place this script on a platform with rigidbody and box collider with no friction material

    [SerializeField]
    private Vector3 velocity;

    private bool moving;
    private float speed = 2f;
    private Vector2 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
            moving = false;
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            transform.position += (velocity * Time.deltaTime);
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{

    Rigidbody2D rb;

    public float speed;
    public float leftAngle;
    public float rightAngle;

    bool movingClockwise;

    public GameObject enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log(transform.rotation.z);*/
        Move();
    }

    public void ChangeMoveDir()
    {
        if(transform.rotation.z > rightAngle)
        {
            if (movingClockwise)
            {
                Flip();
            }
            movingClockwise = false;
            
        }

        if(transform.rotation.z < leftAngle)
        {
            if(!movingClockwise)
            {
                Flip();
            }
            movingClockwise = true;
        }
    }

    private void Flip()
    {
        Vector3 localScale = enemy.transform.localScale;
        localScale.x *= -1f;
        enemy.transform.localScale = localScale;
    }

    public void Move()
    {
        ChangeMoveDir();
        if(movingClockwise)
        {
            rb.angularVelocity = speed;
        }

        if(!movingClockwise)
        {
            rb.angularVelocity = -1 * speed;
        }
    }
}

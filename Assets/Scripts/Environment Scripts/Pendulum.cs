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
            movingClockwise = false;
        }

        if(transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
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

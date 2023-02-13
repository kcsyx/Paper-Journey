using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    public int patrolDestination;

    public Transform playerTransform;
/*    public bool isChasing;
    public float chaseDistance;*/

    // Update is called once per frame
    void Update()
    {
        /*        if (isChasing)
                {
                    if(transform.position.x > playerTransform.position.x)
                    {
                        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        transform.position += Vector3.left * speed * Time.deltaTime;
                    }
                    if (transform.position.x < playerTransform.position.x)
                    {
                        transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
                        transform.position += Vector3.right * speed * Time.deltaTime;
                    }
                }
                else
                {
                    if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
                    {
                        isChasing = true;
                    }

                    if (patrolDestination == 0)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, speed * Time.deltaTime);
                        if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.2f)
                        {
                            Flip();
                            patrolDestination = 1;
                        }
                    }

                    if (patrolDestination == 1)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, speed * Time.deltaTime);
                        if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.2f)
                        {
                            Flip();
                            patrolDestination = 0;
                        }
                    }
                }*/
        if (patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.2f)
            {
                Flip();
                patrolDestination = 1;
            }
        }

        if (patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.2f)
            {
                Flip();
                patrolDestination = 0;
            }
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}

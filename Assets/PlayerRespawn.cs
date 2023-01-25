using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint;
    public GameObject fallDetector;

    void Start()
    {
        respawnPoint = transform.position;
    }

    void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fall Detector")
        {
            transform.position = respawnPoint;
        }

        if (collision.tag == "Checkpoint")
        {
            respawnPoint = collision.transform.position;
        }
    }
}

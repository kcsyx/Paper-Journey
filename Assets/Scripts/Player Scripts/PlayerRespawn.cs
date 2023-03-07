using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //temp

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint;
    public GameObject fallDetector;
    PlayerHealth playerHealth;
    public int fallDamage = 1;

    void Start()
    {
        respawnPoint = transform.position;
        playerHealth = GetComponent<PlayerHealth>();
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
            playerHealth.takeDamage(fallDamage);
            
        }

        if (collision.tag == "Checkpoint")
        {
            respawnPoint = collision.transform.position;
        }

        //temp
        if (collision.tag == "Goal")
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}

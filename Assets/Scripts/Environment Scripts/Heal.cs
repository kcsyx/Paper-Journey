using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public float speed = 0.2f;
    private float initialY;

    private void Start()
    {
        initialY = gameObject.transform.position.y;
    }
    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 0.2f);
        gameObject.transform.localPosition = new Vector3(gameObject.transform.position.x, initialY+y, gameObject.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(playerHealth.currHp < playerHealth.maxHp)
            {
                playerHealth.currHp += 1;
                Destroy(gameObject);
            }
        }
    }
}

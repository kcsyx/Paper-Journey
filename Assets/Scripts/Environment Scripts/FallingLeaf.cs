using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLeaf : MonoBehaviour
{
    Rigidbody2D rb;
    bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isFalling)
        {
            LeafManager.LeafManagerInstance.StartCoroutine("SpawnLeaf", new Vector2(transform.position.x, transform.position.y));
            Invoke("DropLeaf", 0.5f);
            isFalling = true;
            Destroy(gameObject, 2f);
        }
    }

    void DropLeaf()
    {
        rb.isKinematic = false;
    }
}

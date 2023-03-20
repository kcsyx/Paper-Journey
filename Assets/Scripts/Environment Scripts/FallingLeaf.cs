using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLeaf : MonoBehaviour
{
    Rigidbody2D rb;
    bool isFalling = false;

    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isFalling)
        {
            LeafManager.LeafManagerInstance.StartCoroutine("SpawnLeaf", new Vector2(transform.parent.transform.position.x, transform.parent.transform.position.y));
            Invoke("DropLeaf", 0.5f);
            isFalling = true;
            Destroy(transform.parent.gameObject, 2f);
        }
    }

    void DropLeaf()
    {
        rb.isKinematic = false;
    }
}

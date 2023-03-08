using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildPlayer : MonoBehaviour
{
    private HingeJoint2D joint;
    public Rigidbody2D emptyRb;
    public PlayerMovement playerMovement;

    private void Start()
    {
        joint = gameObject.AddComponent<HingeJoint2D>();
        joint.anchor = new Vector2(0, 0f);
    }

    private void Update()
    {
        if (Input.GetButton("Jump") || playerMovement.horizontal != 0)
        {
            joint.connectedBody = emptyRb;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 6f;
    private float jumpingPower = 15f;
    private bool isFacingRight = true;
    private float horizontal;

    private float glidingSpeed = 4f;
    private float initialGravityScale;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    void Start()
    {
        initialGravityScale = rb.gravityScale;
    }

    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");

        //JUMPING
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        //GLIDING
        if (Input.GetButton("Jump") && rb.velocity.y <= 0f)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, -glidingSpeed);
        } else
        {
            rb.gravityScale = initialGravityScale;
        }

        Flip();

    }

    private void FixedUpdate()
    {
        if(KBCounter <= 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        } else
        {
            if (KnockFromRight)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (!KnockFromRight)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            /*            Vector3 localScale = transform.localScale;
                        localScale.x *= -1f;
                        transform.localScale = localScale;*/
            transform.Rotate(0f, 180f, 0f);
        }
    }
}

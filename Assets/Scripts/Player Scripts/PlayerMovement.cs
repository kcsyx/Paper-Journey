using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Animator anim;
    private float speed = 6f;
    private float jumpingPower = 20f;
    private bool isFacingRight = true;
    private float horizontal;

    private float glidingSpeed = 4f;
    private float initialGravityScale;
    private bool isGliding = false;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;
    
    private bool isGrounded = true;
    [SerializeField] private Rigidbody2D rb;

    public Shoot playerShoot;

    void Start()
    {
        initialGravityScale = rb.gravityScale;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        //JUMPING
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        //GLIDING
        if (Input.GetButton("Jump") && rb.velocity.y <= 0f)
        {
            playerShoot.enabled = false;
            isGliding = true;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, -glidingSpeed);
        } else
        {
            playerShoot.enabled = true;
            anim.SetBool("isGliding", false);
            isGliding = false;
            rb.gravityScale = initialGravityScale;
        }

        Flip();

    }

    private void FixedUpdate()
    {
        if (horizontal != 0 && isGrounded)
        {
            anim.SetBool("isRunning", true);
        } else
        {
            anim.SetBool("isRunning", false);
        }

        if (isGrounded)
        {
            isGliding = false;
            anim.SetBool("isGliding", false);
            anim.SetBool("isJumping", false);
        }

        if (!isGrounded)
        {
            if (isGliding)
            {
                anim.SetBool("isGliding", true);
            }
            else if (rb.velocity.y > 0)
            {
                anim.SetBool("isJumping", true);
            }
            if(rb.velocity.y == 0)
            {
                anim.SetBool("isGliding", false);
            }
        }

        if (KBCounter <= 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        } 
        
        else
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
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

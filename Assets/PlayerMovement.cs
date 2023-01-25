using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 8f;
    private float jumpingPower = 15f;
    private bool isFacingRight = true;
    private float horizontal;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

/*    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 30f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;*/

    private float glidingSpeed = 2f;
    private float initialGravityScale;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        initialGravityScale = rb.gravityScale;
    }

    void Update()
    {
/*        if (isDashing)
        {
            return;
        }*/

        horizontal = Input.GetAxisRaw("Horizontal");

        //JUMPING
        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        } else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0 && jumpBufferCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            jumpBufferCounter = 0f;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
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

        //DASHING
/*        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }*/

        Flip();

    }

    private void FixedUpdate()
    {
/*        if (isDashing)
        {
            return;
        }*/

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
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

/*    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(horizontal * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = initialGravityScale;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }*/
}

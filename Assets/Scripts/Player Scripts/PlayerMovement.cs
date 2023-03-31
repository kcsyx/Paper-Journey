using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Animator anim;
    private float speed = 6f;
    private float jumpingPower = 17f;
    private bool isFacingRight = true;
    public float horizontal;

    private float glidingSpeed = 4f;
    private float initialGravityScale;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;
    
    public bool isGrounded = true;
    [SerializeField] private Rigidbody2D rb;

    public ParticleController particleController;
    public Shoot playerShoot;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;

    public bool canMove = true;
    public bool canJump = true;

    private float airJumpsRemaining = 1;

    public GameObject[] trails;

    void Start()
    {
        initialGravityScale = rb.gravityScale;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isGrounded)
        {
            StopGliding();

            if (horizontal == 0)
            {
                rb.gravityScale = 0;
            }
            else
            {
                rb.gravityScale = initialGravityScale;
            }

            if (horizontal != 0)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }

            coyoteTimeCounter = coyoteTime;
            airJumpsRemaining = 1;

            if(rb.velocity.y <= 5)
            {
                
                anim.SetBool("isJumping", false);
            }
        }

        else
        {
            coyoteTimeCounter -= Time.deltaTime;
            anim.SetBool("isRunning", false);

            //GLIDING
            if (Input.GetKey(KeyCode.LeftShift) && rb.velocity.y < 0f)
            {
                Glide();
            }
            else
            {
                StopGliding();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                AudioManager.instance.sfxSource.Stop();
                AudioManager.instance.PlaySFX("glide");
            }

        }

        if (canMove)
        {
            Move();
        }

        if (canJump)
        {
            if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
            {
                Jump();
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                coyoteTimeCounter = 0;
            }

            if (!isGrounded && Input.GetButtonDown("Jump"))
            {
                if (airJumpsRemaining > 0 && coyoteTimeCounter <= 0f)
                {
                    anim.SetBool("isJumping", false);
                    Jump();
                    airJumpsRemaining--;
                }
            }

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            AudioManager.instance.sfxSource.Stop();
        }

        Flip();
    }

    private void FixedUpdate()
    {
        CheckSurroundings();

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

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void Jump()
    {
        anim.SetBool("isJumping", true);
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        AudioManager.instance.PlaySFX("jump");
    }

    private void Glide()
    {
        trails[0].SetActive(true);
        trails[1].SetActive(true);
        anim.SetBool("isGliding", true);
        playerShoot.canFire = false;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(rb.velocity.x, -glidingSpeed);
    }

    private void StopGliding()
    {
        trails[0].GetComponent<TrailRenderer>().Clear();
        trails[1].GetComponent<TrailRenderer>().Clear();
        trails[0].SetActive(false);
        trails[1].SetActive(false);
        anim.SetBool("isGliding", false);
        playerShoot.canFire = true;
        rb.gravityScale = initialGravityScale;
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            particleController.fallParticle.Play();
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

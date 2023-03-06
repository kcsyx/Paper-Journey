using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem movementParticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D rb;

    float counter;
    bool isOnGround;

    public ParticleSystem fallParticle;

    void Update()
    {
        isOnGround = rb.GetComponent<PlayerMovement>().isGrounded;
        counter += Time.deltaTime;

        if(isOnGround && (Mathf.Abs(rb.velocity.x)) > occurAfterVelocity)
        {
            if(counter > dustFormationPeriod)
            {
                movementParticle.Play();
                counter = 0;
            }
        }
    }


}

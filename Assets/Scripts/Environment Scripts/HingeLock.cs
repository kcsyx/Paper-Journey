using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeLock : MonoBehaviour
{
    new HingeJoint2D hingeJoint;
    JointAngleLimits2D limits;
    Rigidbody2D rb;
    public ParticleSystem fallParticle;
    private bool fell = false;
    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        limits = hingeJoint.limits;
    }

    // Update is called once per frame
    void Update()
    {
        if(hingeJoint.jointAngle >= 89)
        {
            limits.min = 90;
            limits.max = 90;
            hingeJoint.limits = limits;
            hingeJoint.useLimits = true;
            rb.bodyType = RigidbodyType2D.Static;
            if (!fell)
            {
                fallParticle.Play();
                fell = true;
            }
        }
    }
}

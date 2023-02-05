using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeLock : MonoBehaviour
{
    new HingeJoint2D hingeJoint;
    JointAngleLimits2D limits;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();
        limits = hingeJoint.limits;
    }

    // Update is called once per frame
    void Update()
    {
        if(hingeJoint.jointAngle >= 90)
        {
            limits.min = 90;
            limits.max = 90;
            hingeJoint.limits = limits;
            hingeJoint.useLimits = true;
        }
    }
}

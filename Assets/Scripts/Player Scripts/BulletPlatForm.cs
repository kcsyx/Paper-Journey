using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlatForm : MonoBehaviour
{

    void Update()
    {
        Destroy(gameObject, 1.2f);
    }
}

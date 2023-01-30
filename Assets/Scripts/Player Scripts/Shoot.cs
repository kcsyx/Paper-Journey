using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public Transform shootingPoint;
    public GameObject bulletPrefab;

    public float cooldown;
    public float lastShot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Time.time - lastShot < cooldown)
            {
                return;
            }
            lastShot= Time.time;
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
    }
}

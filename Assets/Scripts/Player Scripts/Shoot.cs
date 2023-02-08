using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    public Transform shootingPoint;
    public GameObject bulletPrefab;

    public Image cdImage;
    public bool isCooldown;
    public float cooldown;

    public int counter = 0;

    void Start()
    {
        cdImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0) && isCooldown == false)
        {
            isCooldown = true;
            cdImage.fillAmount = 1;
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }

        if (isCooldown)
        {
            cdImage.fillAmount -= 1.0f / cooldown * Time.deltaTime;

            if(cdImage.fillAmount <= 0)
            {
                cdImage.fillAmount = 0;
                isCooldown = false;
            }
        }

    }
}

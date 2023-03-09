using System;
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
    public bool canFire = true;

    public int platformsSpawned;
    public List<GameObject> bullets;

    public LayerMask wallLayer;
    public Transform playerTransform;
    public PlayerMovement playerMovement;
    private bool insideWall;

    void Start()
    {
        platformsSpawned = 0;
        cdImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        insideWall = Physics2D.Linecast(playerTransform.position, shootingPoint.position, wallLayer);
        Fire();
    }

    void Fire()
    {
        if (canFire)
        {
            if (Input.GetMouseButtonDown(0) && isCooldown == false)
            {
                isCooldown = true;
                cdImage.fillAmount = 1;
                if (!insideWall)
                {
                    Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
                }
                else
                {
                    playerMovement.KBCounter = playerMovement.KBTotalTime;
                    if (playerTransform.rotation.y >= 0)
                    {
                        playerMovement.KnockFromRight = true;
                        StartCoroutine(Wait());
                    }
                    else if (playerTransform.rotation.y < 0)
                    {
                        playerMovement.KnockFromRight = false;
                        StartCoroutine(Wait());
                    }
                }
            }
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

    IEnumerator Wait()
    {
        playerMovement.canMove = false;
        yield return new WaitForSeconds(0.2f);
        playerMovement.canMove = true;
        Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CenterCheck : MonoBehaviour
{
    public bool isPlayerInside = false;


    private void Update()
    {
        if(gameObject.GetComponentInParent<Bullet>().IsPlatformOrNot)
        {
            if (isPlayerInside)
            {
                if (gameObject.GetComponentInParent<Bullet>().hasExited)
                {
                    return;
                } else
                {
                    gameObject.GetComponentInParent<Bullet>().bulletCollider[1].enabled = false;
                }
            } else
            {
                gameObject.GetComponentInParent<Bullet>().bulletCollider[1].enabled = true;
                gameObject.GetComponentInParent<Bullet>().gameObject.layer = LayerMask.NameToLayer("Ground");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInside = false;
            gameObject.GetComponentInParent<Bullet>().hasExited = true;
        }
    }
}

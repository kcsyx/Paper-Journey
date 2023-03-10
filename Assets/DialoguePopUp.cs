using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePopUp : MonoBehaviour
{

    public GameObject dialogue;
    public PlayerMovement playerMovement;
    public Shoot playerShoot;

    public PauseMenu pauseMenu;

    private bool passed = false;

    private void Update()
    {
        if(dialogue.GetComponent<Dialogue>().finished)
        {
            playerMovement.canJump = true;
            playerMovement.canMove = true;
            playerMovement.enabled = true;
            playerShoot.enabled = true;
            pauseMenu.canPause = true;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !passed)
        {
            passed = true;
            dialogue.SetActive(true);
            playerMovement.horizontal = 0;  
            playerMovement.canMove = false;
            Debug.Log(playerMovement.canMove);
            playerMovement.canJump = false;
            playerShoot.enabled = false;
            pauseMenu.canPause = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{

    private PlayerController playerController;

    public void Awake()
    {
        playerController = this.transform.root.GetComponent<PlayerController>();
    }

     void OnTriggerStay2D(Collider2D collision)
     {
        if (collision.CompareTag("Ground"))
        {
            if(playerController.PlayerControllerRigidbody2D.velocity.y <= 0)
            {
                playerController.IsGrounded = true;
                playerController.CurrentJumpCount = 0;
            }
            
        }
     }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerController.IsGrounded = false; 
    }
}

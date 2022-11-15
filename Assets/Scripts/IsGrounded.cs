using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{

    private PlayerController playerController;
    private Enemy enemy;

    public void Awake()
    {
        if(this.transform.root.tag == "Player")
        {
            playerController = this.transform.root.GetComponent<PlayerController>();
        }
        else
        {
            enemy = this.transform.root.GetComponent<Enemy>();
        }
        
        
    }

     void OnTriggerStay2D(Collider2D collision)
     {
        if (collision.CompareTag("Ground"))
        {
            if (this.transform.root.tag == "Player")
            {
                if (playerController.PlayerControllerRigidbody2D.velocity.y <= 0)
                {
                    playerController.IsGrounded = true;
                    playerController.CurrentJumpCount = 0;
                }
            }
            else
            {
                if (enemy._rigidbody2D.velocity.y <= 0)
                {
                    enemy.IsGrounded = true;
                    enemy.CurrentJumpCount = 0;
                }
            }

        
            
            
        }
     }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (this.transform.root.tag == "Player")
        {
            playerController.IsGrounded = false;
        }
        else
        {
            enemy.IsGrounded = false;
        }
    }
}

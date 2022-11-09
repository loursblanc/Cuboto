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
            playerController.isGrounded = true;
        }
     }

    void OnTriggerExit2D(Collider2D collision)
    {
        playerController.isGrounded = false; 
    }
}

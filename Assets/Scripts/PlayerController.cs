using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("[Status]")]
    public bool IsGrounded;
    [SerializeField] private bool IsCrouch = false;
    public int CurrentJumpCount = 0;

    [Header("[Setting]")]
    [SerializeField] private int JumpCount = 1;
    [SerializeField] private float jumpForce = 2.75f;

    protected Animator Anim;
    public Rigidbody2D PlayerControllerRigidbody2D;


    private void Awake()
    {
        Anim = this.transform.Find("SwordMan").GetComponent<Animator>();
        PlayerControllerRigidbody2D = this.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        CheckInput();
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            IsCrouch = true;
            Anim.Play("Sit");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Anim.Play("Run");
            IsCrouch = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))     
        {

            //TODO: Manage the case where the force is too high on the second jump
            if (IsGrounded || CurrentJumpCount < JumpCount)
            {
                CurrentJumpCount++;
                Anim.Play("Jump");
                PlayerControllerRigidbody2D.AddForce(Vector2.up * (100 * (jumpForce)));
            }
        }
    }
}
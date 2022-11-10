using System.Collections;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{

    [Header("[Status]")]
    public bool IsGrounded;
    [SerializeField] protected bool IsCrouch = false;
    public int CurrentJumpCount = 0;

    [Header("[Setting]")]
    [SerializeField] protected int JumpCount = 1;
    public float jumpForce = 3f;

    protected Animator Anim;
    public Rigidbody2D PlayerControllerRigidbody2D;
    protected CapsuleCollider2D playerCapsuleCollider2D;



    private void Awake()
    {
        Anim = this.transform.Find("SwordMan").GetComponent<Animator>();
        PlayerControllerRigidbody2D = this.GetComponent<Rigidbody2D>();
        playerCapsuleCollider2D = this.GetComponent<CapsuleCollider2D>();

    }


private void Update()
    {
        CheckInput();
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CrounchDown();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            CrounchUp();
        }

        if (Input.GetKeyDown(KeyCode.Space))     
        {
            Jump();
        }
    }

    private void Jump()
    {
        //TODO: Manage the case where the force is too high on the second jump
        if (IsGrounded || CurrentJumpCount < JumpCount)
        {
            CurrentJumpCount++;
            Anim.Play("Jump");
            PlayerControllerRigidbody2D.AddForce(Vector2.up * (100 * (jumpForce)));
        }
    }

    
    protected virtual void CrounchDown()
    {
        IsCrouch = true;
        Anim.Play("Sit");
    }

    protected virtual void CrounchUp()
    {
        Anim.Play("Run");
        IsCrouch = false;
    }
}
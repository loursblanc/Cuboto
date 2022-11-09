using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("[Status]")]
    public bool IsGrounded;
    [SerializeField] private bool IsCrouch = false;
    [SerializeField] private int currentJumpCount = 0;

    [Header("[Setting]")]
    public int JumpCount = 2;
    public float jumpForce = 15f;

    protected Animator Anim;


    private void Awake()
    {
        Anim = this.transform.Find("SwordMan").GetComponent<Animator>();
    }


    private void Update()
    {
        checkInput();
    }

    public void checkInput()
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
    }
}
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("[Status]")]
    public bool isGrounded;
    [SerializeField] private bool IsSit = false;
    [SerializeField]  private int currentJumpCount = 0;

    [Header("[Setting]")]
    public float MoveSpeed = 6;
    public int JumpCount = 2;
    public float jumpForce = 15f;






}
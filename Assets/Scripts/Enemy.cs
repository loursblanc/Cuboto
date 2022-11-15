using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Move")]
        public int speed = 10;
        
    [Header ("Roll")]
        public bool RollIsPossible;
        [Range(0,100)]
        public int PercentageOfRolling;

    [Header("Jump")]
        public bool JumpIsPossible;
        [Range(0, 100)]
        public int PercentageOfJump;
        public float JumpForce;
        

    [Header("Status")]
        public bool IsGrounded;
        public int CurrentJumpCount;

    [Header("Gameplay")]
    public int ScoreValue = 10;

    public Rigidbody2D _rigidbody2D;
    private Movement movement;

    private void Awake()
    {       
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        if(Random.Range(0,100) > 70){
            _rigidbody2D.freezeRotation = false;
        }
        movement = new Movement(JumpForce);

        if (RollIsPossible)
        {
            Roll();
        }

        if (JumpIsPossible)
        {
            if (Random.Range(0, 100) < PercentageOfJump)
            {
                StartCoroutine(Jump());
            }
                
        }
    }

    void FixedUpdate()
    {
        _rigidbody2D.AddForce(movement.EnemyMoveLeft(speed),ForceMode2D.Impulse);
        
        if(transform.position.x < -17)
        {
            GameManager.CurrentScore += ScoreValue;            
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("TouchByEnemy");
            GameManager.GameState = GameManager.GAMESTATE.Over;
            Destroy(this.gameObject);   
        }
    }

    private void Roll()
    {
        if (Random.Range(0, 100) < PercentageOfRolling)
        {
            _rigidbody2D.freezeRotation = false;
        }
    }


    private IEnumerator Jump()
    {
        
        while (true)
        {
            
            //TODO: Manage the case where the force is too high on the second jump
            if (IsGrounded)
            {
               _rigidbody2D.AddForce(movement.Jump());
            }
                
            yield return new WaitForSeconds(0.3f);
        }
    }
}

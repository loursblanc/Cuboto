using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement

{
    private float JumpForce;
    public float ForForceMultiplierce = 100;

    public Movement(float jumpForce)
    {
        JumpForce = jumpForce;
    }


    public Vector2 Jump()
    {       
            return (Vector2.up * (ForForceMultiplierce * (JumpForce)));
    }
    
}

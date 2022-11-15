using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement

{
    private float Jumpforce;
    public float ForceMultiplierce = 100;


    public Movement(float jumpforce)
    {
        Jumpforce = jumpforce;
    }

    public Vector2 Jump()
    {       
            return (Vector2.up * (ForceMultiplierce * (Jumpforce)));
    }

    public Vector2 EnemyMoveLeft(float speed)
    {
        return Vector2.left * (0.1f * (speed / 10));
    }    
}

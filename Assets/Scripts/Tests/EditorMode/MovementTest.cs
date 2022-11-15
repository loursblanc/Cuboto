using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTest
{
    private Movement movement;
    private float JumpForce = 3;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        movement = new Movement(JumpForce);
    }    
    
    [Test]
    public void JumpIsOk()
    {
        Vector2 jump = movement.Jump();
        float jumpY = movement.ForceMultiplierce * JumpForce;
        Vector2 expected = new Vector2(0, jumpY);
        Assert.AreEqual(expected, jump);       
    }
}

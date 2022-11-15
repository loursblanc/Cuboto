using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SwordManControllerTesting 
{

    SwordManController swordManController;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
             }

    [UnityTest]
    public IEnumerator JumpIsOk()
    {
        //swordManController.IsGrounded = true;
        //swordManController.Jump();
        yield return null;
        //Assert.IsTrue(swordManController.PlayerControllerRigidbody2D.velocity.y > 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManController : PlayerController
{

    private float capsuleSizeYCrounch = 0.086f;
    private float capsuleSizeYStand = 0.24f;
    private float capsuleOffsetYCrounch = 1.077f;
    private float capsuleOffsetYStand = 1.33f;


    public override void CrounchDown()
    {
        IsCrouch = true;
        Anim.Play("Sit");
        playerCapsuleCollider2D.offset = new Vector2(playerCapsuleCollider2D.offset.x, capsuleSizeYCrounch);
        playerCapsuleCollider2D.size = new Vector2(playerCapsuleCollider2D.size.x, capsuleOffsetYCrounch);

    }    


    public override void CrounchUp()
    {
        IsCrouch = false;
        Anim.Play("Run");
        playerCapsuleCollider2D.offset = new Vector2(playerCapsuleCollider2D.offset.x, capsuleSizeYStand);
        playerCapsuleCollider2D.size = new Vector2(playerCapsuleCollider2D.size.x, capsuleOffsetYStand);
    }


}

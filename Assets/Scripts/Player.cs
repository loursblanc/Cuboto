using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Animator Anim;

    private void Awake()
    {
        Anim = this.transform.Find("SwordMan").GetComponent<Animator>();
    }

 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public Animator anim;
    public Animator swordAnimation;
    //public SpriteRenderer spriteRenderer;

    void Start()
    {
        anim = GetComponentInChildren<Animator>(); //GetComponent<Animator>();
        //spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        swordAnimation = transform.GetChild(1).GetComponent<Animator>();
    }
 

    public void Move(float move)
    {
        anim.SetFloat("move", Mathf.Abs(move));
    }

    public void isJump(bool jump)
    {
        anim.SetBool("isJumping", jump);
    }


    public void isAttack()
    {
        anim.SetTrigger("attack");
        swordAnimation.SetTrigger("SwordAnimation");
    }

    public void RunAttack()
    {
        anim.SetTrigger("attack");

    }
}

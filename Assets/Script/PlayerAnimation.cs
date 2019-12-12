using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator _anim;
    private Animator _swordAnimation;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordAnimation = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move (float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jump)
    {
        _anim.SetBool("Jump", jump);
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _swordAnimation.SetTrigger("SwordAnimation");
    }

    public void Hit()
    {
        _anim.SetTrigger("Hit");
        Debug.Log("Hit");
    }

    public void Death(bool death)
    {
        _anim.SetBool("Death", death);
    }
     
    void Update()
    {
        
    }
}

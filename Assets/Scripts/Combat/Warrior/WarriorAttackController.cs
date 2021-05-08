using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAttackController : AttackController
{
    Animator _animator;
    void Start(){
        _animator = GetComponent<Animator>();
    }

    override public void Attack(){
        _animator.SetTrigger("Attack");
    }
}

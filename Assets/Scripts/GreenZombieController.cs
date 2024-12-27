using System;
using UnityEngine;

public class GreenZombieController : ZombieController
{
    public Animator animator;
    public float greenZombieAttackDistance = 2f;
    public override void Start()
    {
        base.Start();
        attackDistance = greenZombieAttackDistance;
    }
    
    public override void Walk()
    {
        base.Walk();
        animator.SetTrigger("ZombieWalk");
    }

    public override void Attack()
    {
        animator.SetTrigger("ZombieAttack");
    }
    public override void StopAttack()
    {
        animator.SetTrigger("ZombieWalk");
    }
    public override void Kill()
    {
        base.Kill();
        animator.SetTrigger("ZombieKill");
    }
}

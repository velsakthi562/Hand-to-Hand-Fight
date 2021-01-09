using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Walk(bool move)
    {
        animator.SetBool(AnimationTags.MOVEMENT, move);
    }
    public void Punch()
    {
        animator.SetTrigger(AnimationTags.PUNCH);
    }
    public void Punch2()
    {
        animator.SetTrigger(AnimationTags.PUNCH2);
    }
    public void Punch3()
    {
        animator.SetTrigger(AnimationTags.PUNCH3);
    }
    public void Kick1()
    {
        animator.SetTrigger(AnimationTags.KICK1);
    }
    public void Kick2()
    {
        animator.SetTrigger(AnimationTags.KICK2);
    }
    //public void Kick3()
    //{
        //animator.SetTrigger(AnimationTags.KICK3);
    //}
        //Enemy Animations

        public void EnemyAttack(int attack)
    {
        if(attack == 0)
        {
            animator.SetTrigger(AnimationTags.ATTACK1);
        }
        if (attack == 1)
        {
            animator.SetTrigger(AnimationTags.ATTACK2);
        }
        if (attack == 2)
        {
            animator.SetTrigger(AnimationTags.ATTACK3);
        }

    }
    public void PlayIdle()
    {
        animator.Play(AnimationTags.IDLE);
    }

    public void KnockDown()
    {
        animator.SetTrigger(AnimationTags.KNOCKDOWN);
    }
    public void StandUp()
    {
        animator.SetTrigger(AnimationTags.STANDUP);
    }
    public void Hit()
    {
        animator.SetTrigger(AnimationTags.HIT);
    }
    public void Death()
    {
        animator.SetTrigger(AnimationTags.DEATH);
    }
}

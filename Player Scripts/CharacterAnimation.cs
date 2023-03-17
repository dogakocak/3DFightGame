using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private static readonly int Movement = Animator.StringToHash("Movement");
    private static readonly int Punch1 = Animator.StringToHash("Punch1");
    private static readonly int Punch2 = Animator.StringToHash("Punch2");
    private static readonly int Punch3 = Animator.StringToHash("Punch3");
    private static readonly int Kick1 = Animator.StringToHash("Kick1");
    private static readonly int Kick2 = Animator.StringToHash("Kick2");
    private static readonly int Up = Animator.StringToHash("StandUp");
    private static readonly int Down = Animator.StringToHash("KnockDown");
    private static readonly int Hit1 = Animator.StringToHash("Hit");
    private static readonly int Death1 = Animator.StringToHash("Death");

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool move)
    {
        anim.SetBool(Movement, move);
    }

    public void Punch_1()
    {
        anim.SetTrigger(Punch1);
    }
    
    public void Punch_2()
    {
        anim.SetTrigger(Punch2);
    }
    
    public void Punch_3()
    {
        anim.SetTrigger(Punch3);
    }

    public void Kick_1()
    {
        anim.SetTrigger(Kick1);
    }

    public void Kick_2()
    {
        anim.SetTrigger(Kick2);
    }

    public void EnemyAttack(int attack)
    {
        if (attack == 0)
        {
            anim.SetTrigger("Attack1");
        }
        else if (attack == 1)
        {
            anim.SetTrigger("Attack2");
           
        }
        else if (attack == 2)
        {
            anim.SetTrigger("Attack3");
        }

    }

    public void Play_IdleAnimation()
    {
        anim.Play("Idle");
    }

    public void KnockDown()
    {
        anim.SetTrigger(Down);
    }

    public void StandUp()
    {
        anim.SetTrigger(Up);
    }

    public void Hit()
    {
        anim.SetTrigger(Hit1);
    }

    public void Death()
    {
        anim.SetTrigger(Death1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionScript : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    //// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //   //if (SwordSlash.instance.isAttacking)
    //   // {
    //   //     SwordSlash.instance.myAnim.Play("Attack 2");
    //   //     SwordSlash.instance.sr.color = Color.red;
    //   //     //Debug.Log("Second slash");
    //   // }

    //    if (T_MeleeAttack.instance.isAttacking)
    //    {
    //        T_MeleeAttack.instance.weaponAnimator.Play("Attack 2");
    //        T_MeleeAttack.instance.weaponSprite.color = Color.red;

    //        T_MeleeAttack.instance.weaponCollider.enabled = true;

    //        //Debug.Log("First slash");
    //    }
    //    else
    //    {
    //        T_MeleeAttack.instance.weaponCollider.enabled = false;

    //    }
    //}

    //// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    //SwordSlash.instance.isAttacking = false;

    //    T_MeleeAttack.instance.isAttacking = false;

    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

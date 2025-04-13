using UnityEngine;
using UnityEngine.AI;

public class OrderState : StateMachineBehaviour
{
    private float timeIdle = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("timeIdle", 0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeIdle += Time.deltaTime;
        animator.SetFloat("timeIdle", timeIdle);
    }
}

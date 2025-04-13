using UnityEngine;
using UnityEngine.AI;

public class LeaveState :StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Vector3 target;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Waypoint 2").transform.position;
        agent.SetDestination(target);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(animator.transform.position, target) < 1)
        {
            animator.gameObject.SetActive(false);
        }
    }
}

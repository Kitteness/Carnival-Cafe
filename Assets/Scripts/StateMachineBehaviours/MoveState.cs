using UnityEngine;
using UnityEngine.AI;

public class MoveState :StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Vector3 target;
    private GameObject helloPanel;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        helloPanel = GameObject.FindGameObjectWithTag("Logic Manager").GetComponent<CustomerManagement>().helloPanel;
        target = GameObject.FindGameObjectWithTag("Waypoint 1").transform.position;
        agent.SetDestination(target);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (Vector3.Distance(animator.transform.position, target) < 1)
        {
            animator.SetBool("Order", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        helloPanel.SetActive(true);
    }
}

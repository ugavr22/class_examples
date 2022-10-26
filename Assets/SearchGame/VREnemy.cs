using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class VREnemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;
    [SerializeField] Rigidbody physics;
    [SerializeField] Animator body;
    // Start is called before the first frame update
    void Start()
    {
        agent.updatePosition = false;
    }

	private void OnAnimatorMove()
	{

        transform.position = body.rootPosition;
        agent.nextPosition = body.rootPosition;
	}

	// LateUpdate is called after animation is completed
	void LateUpdate()
    {

        //Vector3 offset = target.position-transform.position;
        if(agent.remainingDistance < agent.stoppingDistance)
		{
            body.SetBool("walking", false);
		}
		else
		{
            body.SetBool("walking", true);
        }
        agent.SetDestination(target.position);
        transform.forward = agent.desiredVelocity.normalized;
        body.SetFloat("walkspeed", agent.desiredVelocity.magnitude);
        //physics.velocity = (agent.transform.position - physics.position) / Time.deltaTime;
        //Vector3 walkVelocity = physics.velocity;
        //walkVelocity.y = 0;

        //if (agent.velocity.magnitude > .1f)
        //{
        //    body.transform.forward = agent.velocity.normalized;
        //}
        //body.SetFloat("walkspeed", agent.velocity.magnitude/1.5f);
    }
}

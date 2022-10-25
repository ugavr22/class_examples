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
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        physics.velocity = (agent.transform.position - physics.position) / Time.deltaTime;
        Vector3 walkVelocity = physics.velocity;
        walkVelocity.y = 0;

        if (agent.velocity.magnitude > .1f)
        {
            body.transform.forward = agent.velocity.normalized;
        }
        body.SetFloat("walkspeed", agent.velocity.magnitude/1.5f);
    }
}

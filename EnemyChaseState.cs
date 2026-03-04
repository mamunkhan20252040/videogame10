using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : StateMachineBehaviour
{

    

    NavMeshAgent agent;
    
    Transform player;

    public float chaseSpeed = 6f;

    public float stopChasingDistance = 19;

    public float attackingDistance = 2.5f;

    

    



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

       

       player = GameObject.FindGameObjectWithTag("Player").transform;
       agent = animator.GetComponent<NavMeshAgent>();
       

       agent.speed = chaseSpeed;

       

       
       



    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       agent.SetDestination(player.position);

       Vector3 playerPos = player.position;
       Vector3 agentPos = animator.transform.position;

       Vector3 flatPlayerPos = new Vector3(playerPos.x, 0, playerPos.z);
       Vector3 flatAgentPos = new Vector3(agentPos.x, 0, agentPos.z);
       
       
       animator.transform.LookAt(player);

       float distanceFromPlayer = Vector3.Distance(flatPlayerPos, flatAgentPos);

       if(distanceFromPlayer > stopChasingDistance)
        {
            animator.SetBool("isChasing", false);
            
            
        }

        

        if(distanceFromPlayer < attackingDistance)
        {
            animator.SetBool("isAttacking", true);
            
            
        }


        



     

    }

   

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       agent.SetDestination(animator.transform.position);
    }
}

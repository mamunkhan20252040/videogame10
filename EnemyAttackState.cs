using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackState : StateMachineBehaviour
{
    
    

    Transform player;
    NavMeshAgent agent;
    

    public float stopAttackingDistance = 2.5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       agent = animator.GetComponent<NavMeshAgent>();
       

       
       
       
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       LookAtPlayer();

       Vector3 playerPos = player.position;
       Vector3 agentPos = animator.transform.position;

       Vector3 flatPlayerPos = new Vector3(playerPos.x, 0, playerPos.z);
       Vector3 flatAgentPos = new Vector3(agentPos.x, 0, agentPos.z);
        

       float distanceFromPlayer = Vector3.Distance(flatPlayerPos, flatAgentPos);

       if(distanceFromPlayer > stopAttackingDistance)
        {
            animator.SetBool("isAttacking", false);
            
            
        }


        

        

    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.position - agent.transform.position;
        agent.transform.rotation = Quaternion.LookRotation(direction);

        var yRotation = agent.transform.eulerAngles.y;
        
        agent.transform.rotation = Quaternion.Euler(0,yRotation,0);

    }

}

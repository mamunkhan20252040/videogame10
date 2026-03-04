using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy7 : MonoBehaviour
{
    public float HP = 100;
    private Animator animator;

    private NavMeshAgent navAgent;

    public Player _player_;

    Transform player;

    private LookAtPlayer lookAtPlayer;
    private LockRotationX lockRotationX;
    private CapsuleCollider capsuleCollider;

    //private GameObject itemToDropPrefab;
    public GameObject itemToDropPrefab1;
    public GameObject itemToDropPrefab2;

    public Transform lootSpawnPositionAndRotation1;
    public Transform lootSpawnPositionAndRotation2;

    

    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lookAtPlayer = GetComponent<LookAtPlayer>();
        lockRotationX = GetComponent<LockRotationX>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        //itemToDropPrefab = GameObject.FindGameObjectWithTag("PistolAmmo");
        
    }




    public void TakeDamage(float damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            float randomValue = Random.Range(0, 2);
            Invoke("DisableAnimator", 4f);
            Invoke("DisableNavMeshAgent", 4f);
            lookAtPlayer.enabled = false;
            lockRotationX.enabled = false;
            capsuleCollider.enabled = false;
            Instantiate(itemToDropPrefab1, lootSpawnPositionAndRotation1.position, lootSpawnPositionAndRotation1.rotation);
            Instantiate(itemToDropPrefab2, lootSpawnPositionAndRotation2.position, lootSpawnPositionAndRotation2.rotation);
            //Destroy(gameObject, 5f);
            

            if (randomValue == 0)
            {
                animator.SetTrigger("DIE1");
            }
            else
            {
                animator.SetTrigger("DIE2");
            }

        }
        else
        {
            animator.SetTrigger("DAMAGE");
        }
    }

    public void DisableAnimator()
    {
        animator.enabled = false;
    }

    public void DisableNavMeshAgent()
    {
        navAgent.enabled = false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.5f); //Attacking //Stop Attacking

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 19f); // Detection (Start Chasing)

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 20f); // Stop Chasing
    }

    public void _TakeDamage_()
    {
        _player_.TakeDamage(_player_.damage);
    }
}

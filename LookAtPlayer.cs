using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    public Transform player;

    public float activationRange = 5f;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer < activationRange)
        {
            transform.LookAt(player.transform);
        }
        
    }
    
}

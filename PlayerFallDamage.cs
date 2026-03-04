using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallDamage : MonoBehaviour
{
    public float maxSafeFallTime = 1.5f; // Time player can fall without damage
    public float damagePerSecond = 10f; // Damage dealt for each extra second falling

    private CharacterController controller;
    private float airTime = 0f;
    private Player playerHealth;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerHealth = GetComponent<Player>();
    }

    void Update()
    {
        if (!controller.isGrounded)
        {
            airTime += Time.deltaTime;
        }
        else
        {
            if(airTime > maxSafeFallTime)
            {
                float damage = (airTime - maxSafeFallTime) * damagePerSecond;
                if(playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                }
            }
            airTime = 0f;
        }
    }
}

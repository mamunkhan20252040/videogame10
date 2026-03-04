using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallDamage2 : MonoBehaviour
{
    public float threshold;

    private Player playerHealth;
    public HealthBar healthBar;
    public GameObject pistol;
    public GameObject AmmoDisplay;

    public void Start()
    {
        playerHealth = GetComponent<Player>();
        //healthBar = GetComponent<HealthBar>();
    }

    public void FixedUpdate()
    {
        float damage = 100f;
        if(transform.position.y < threshold)
        {
            //transform.position = new Vector3(-74.47f, 0.5799998f, 81.99f);
            //transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            playerHealth.TakeDamage(damage);
            healthBar.SetHealth(playerHealth.HP);
            pistol.SetActive(false);
            AmmoDisplay.SetActive(false);
        }
    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            print("hit " + collision.gameObject.name + " !");
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy7"))
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
            collision.gameObject.GetComponent<Enemy7>().TakeDamage(bulletDamage);
            //collision.gameObject.GetComponent<Enemy8>().TakeDamage(bulletDamage);
            //Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy8"))
        {
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
            //collision.gameObject.GetComponent<Enemy7>().TakeDamage(bulletDamage);
            collision.gameObject.GetComponent<Enemy8>().TakeDamage(bulletDamage);
            //Destroy(gameObject);
        }


    }
}

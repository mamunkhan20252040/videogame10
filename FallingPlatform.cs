using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private bool isFalling = false;
    private float downSpeed = 0;




    public void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.CompareTag("Player"))
        {
            isFalling = true;


        }

    }





    public void Update()
    {
        if (isFalling)
        {
            downSpeed += Time.deltaTime / 10;
            transform.position = new Vector3(transform.position.x, transform.position.y - downSpeed / 10, transform.position.z);
        }
    }



}

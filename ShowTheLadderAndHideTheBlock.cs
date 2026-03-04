using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTheLadderAndHideTheBlock : MonoBehaviour
{
    public GameObject ladder_;
    public GameObject block_;

    void Start()
    {
        ladder_.SetActive(false);
        block_.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collisionForShowTheLadderAndHideTheBlock"))
        {
            ladder_.SetActive(true);
            block_.SetActive(false);
        }
    }
}

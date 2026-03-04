using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTheWall : MonoBehaviour
{
    

    public GameObject enemy7_;
    public GameObject enemy8_;

    public GameObject wall;

    void Start()
    {
        
        wall.SetActive(true);
    }

    void Update()
    {
        HideTheWall_();
    }

    public void HideTheWall_()
    {

        if(enemy7_.GetComponent<Enemy7>().HP == 0 && enemy8_.GetComponent<Enemy8>().HP == 0)
        {
            wall.SetActive(false);
        }

    }
}

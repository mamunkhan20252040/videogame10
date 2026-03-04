using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotationX : MonoBehaviour
{

    public float lockedXRotation = 0f;

    void LateUpdate()
    {
        Vector3 currentRotation = transform.eulerAngles;

        transform.rotation = Quaternion.Euler(lockedXRotation, currentRotation.y, currentRotation.z);
    }
    
}

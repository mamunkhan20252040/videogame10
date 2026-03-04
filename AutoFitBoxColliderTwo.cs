using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Renderer))]
public class AutoFitBoxColliderTwo : MonoBehaviour
{
    void Start()
    {
        // Attempt to get existing BoxCollider component, or add one if it doesn't exist
        BoxCollider boxCollider = GetComponent<BoxCollider>();
       
        if (boxCollider == null)
        {
            boxCollider = gameObject.AddComponent<BoxCollider>();
            boxCollider.isTrigger = false;
        }
        // Get the Renderer component to access the object's bounds
        Renderer renderer = GetComponent<Renderer>();
       
        if (renderer != null)
        {
            // Set the collider's size to match the renderer's bounds size
            boxCollider.size = renderer.bounds.size;
           
            // Set the collider's center to match the renderer's bounds center
            // Need to convert world center to local space for the collider's center property
            boxCollider.center = transform.InverseTransformPoint(renderer.bounds.center);
        }
        else
        {
            Debug.LogError("No Renderer found on the GameObject. Cannot auto-size BoxCollider.");
        }
    }
}

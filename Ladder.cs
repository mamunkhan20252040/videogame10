using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Color rayColor = Color.red;

    public Transform rayCastForLadder;

    
    




    // Assign in the Inspector
    public float climbSpeed = 3f;
    public float raycastDistance = 1f;
    public LayerMask whatIsLadder; // Set this in the Inspector to a layer that includes your ladder
    private bool isClimbing = false;
    private CharacterController characterController; // Or Rigidbody rb if using physics movement

    private FirstPersonController firstPersonController;
    void Start()
    {
        characterController = GetComponent<CharacterController>(); // Get the CharacterController
        firstPersonController = GetComponent<FirstPersonController>();
        

    }
    void Update()
    {

        

        Debug.DrawRay(rayCastForLadder.position, rayCastForLadder.forward * raycastDistance, rayColor);

        // Shoot a raycast forward from the player's center to detect the ladder
        RaycastHit hit;
        if (Physics.Raycast(rayCastForLadder.position, rayCastForLadder.forward, out hit, raycastDistance, whatIsLadder))
        {
            if (hit.collider.CompareTag("Ladder") && Input.GetKey(KeyCode.W))
            {
                isClimbing = true;


                firstPersonController.enabled = false;

            }

        }

        if (!Physics.Raycast(rayCastForLadder.position, rayCastForLadder.forward, out hit, raycastDistance, whatIsLadder))
        {
            if (isClimbing)
            {
                isClimbing = false;
                
                firstPersonController.currentMovement.y = firstPersonController.jumpForce/2;

                
                
                firstPersonController.walkSpeed = firstPersonController.walkSpeed/2;

                

                Invoke("increaseWalkSpeedAfterHalfSecond", 0.5f);

                
                
                
                firstPersonController.enabled = true;
            }
            
            

            //isClimbing = false;




            //firstPersonController.enabled = true;



        }

        else
        {
            // If the raycast doesn't hit a ladder, stop climbing (e.g., at the top or bottom)

            if (isClimbing && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                isClimbing = false;

                

                firstPersonController.enabled = true;

            }



        }


        if (isClimbing)
        {
            ClimbLadder();
        }
    }

    


    public void ClimbLadder()
    {
        // Disable regular controls and gravity here if necessary, depending on your player setup
        // For CharacterController, movement is handled directly:
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 climbMovement = transform.up * verticalInput * climbSpeed;
        characterController.Move(climbMovement * Time.deltaTime);
        // Optional: center the player on the ladder's X/Z axis
        // This is more complex and might involve Lerping the position towards the ladder's center point
    }

    public void increaseWalkSpeedAfterHalfSecond()
    {
        firstPersonController.walkSpeed = firstPersonController.walkSpeed*2;
    }






}

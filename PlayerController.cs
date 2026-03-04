using Cinemachine;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController controller;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    
    //[SerializeField] private AudioSource footstepSound;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sprintSpeedMultiplier = 2f;
    [SerializeField] private float sprintTransitSpeed = 5f;
    [SerializeField] private float turningSpeed = 2f;
    [SerializeField] private float gravity = 30f;
    [SerializeField] private float jumpHeight = 2f;

    private float verticalVelocity;
    private float currentSpeed;
    private float currentSpeedMultiplier;
    private float xRotation;

    //[Header("Camera Bob Settings")]
    //[SerializeField] private float bobFrequency = 1f;
    //[SerializeField] private float bobAmplitude = 1f;

    //private CinemachineBasicMultiChannelPerlin noiseComponent;
    //private float bobTimer = 0f;

    //[Header("Footstep Settings")]
    //[SerializeField] private LayerMask terrainLayerMask;
    //[SerializeField] private float stepInterval = 1f;

    //private float nextStepTimer = 0;

    //[Header("SFX")]
    //[SerializeField] private AudioClip[] groundFootsteps;
    //[SerializeField] private AudioClip[] grassFootsteps;
    //[SerializeField] private AudioClip[] gravelFootsteps;

    [Header("Input")]
    public float mouseSensitivity;
    private float moveInput;
    private float turnInput;
    private float mouseX;
    private float mouseY;

    

    private void Start()
    {
        
        controller = GetComponent<CharacterController>();
        //noiseComponent = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        // lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        InputManagement();
        Movement();

        //PlayFootstepSound();
    }

    // private void LateUpdate()
    // {
    //     CameraBob();
    // }

    

    private void Movement()
    {
        GroundMovement();
        Turn();
    }

    private void GroundMovement()
    {
        Vector3 move = new Vector3(turnInput, 0, moveInput);
        move = virtualCamera.transform.TransformDirection(move);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeedMultiplier = sprintSpeedMultiplier;
        }
        else
        {
            currentSpeedMultiplier = 1f;
        }

        

        currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed * currentSpeedMultiplier, sprintTransitSpeed * Time.deltaTime);

        

        move *= currentSpeed;

        

        move.y = VerticalForceCalculation();

        controller.Move(move * Time.deltaTime);
    }

    private void Turn()
    {
        mouseX *= mouseSensitivity * Time.deltaTime;
        mouseY *= mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        virtualCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }

    // private void CameraBob()
    // {
    //     if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
    //     {
    //         noiseComponent.m_AmplitudeGain = bobAmplitude * currentSpeedMultiplier;
    //         noiseComponent.m_FrequencyGain = bobFrequency * currentSpeedMultiplier;
    //     }
    //     else
    //     {
    //         noiseComponent.m_AmplitudeGain = 0.0f;
    //         noiseComponent.m_FrequencyGain = 0.0f;
    //     }
    // }

    // private void PlayFootstepSound()
    // {
    //     if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
    //     {
    //         if (Time.time >= nextStepTimer)
    //         {
    //             AudioClip[] footstepClips = DetermineAudioClips();

    //             if (footstepClips.Length > 0)
    //             {
    //                 AudioClip clip = footstepClips[Random.Range(0, footstepClips.Length)];

    //                 footstepSound.PlayOneShot(clip);
    //             }

    //             nextStepTimer = Time.time + (stepInterval / currentSpeedMultiplier);
    //         }
    //     }
    // }

    // private AudioClip[] DetermineAudioClips()
    // {
    //     RaycastHit hit;

    //     if (Physics.Raycast(transform.position, -transform.up, out hit, 1.5f, terrainLayerMask))
    //     {
    //         string tag = hit.collider.tag;

    //         switch (tag)
    //         {
    //             case "Ground":
    //                 return groundFootsteps;
    //             case "Grass":
    //                 return grassFootsteps;
    //             case "Gravel":
    //                 return gravelFootsteps;
    //             default:
    //                 return groundFootsteps;
    //         }
    //     }
    //     return groundFootsteps;
    // }

    private float VerticalForceCalculation()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -1;

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * gravity * 2);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        return verticalVelocity;
    }

    private void InputManagement()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }
}

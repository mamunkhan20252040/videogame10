using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Cinemachine;


public class Player : MonoBehaviour
{
   

    //[SerializeField] private CameraShake cameraShake;

    public TextMeshProUGUI deadAndRespawnText;
    public GameObject deadAndRespawnPanel;

    public GameObject HealthBar;

    public GameObject Timer;

    

     [SerializeField] private Transform player;
     [SerializeField] private Transform respawnPoint;


    
    //[SerializeField] private float shakeIntensity = 5f;
    //[SerializeField] private float shakeTime = 1f;

    private FirstPersonController firstPersonController;
    private BringUpSettings bringUpSettings;

    [SerializeField] private Camera camera;

    

    public float HP = 100f;

    public float damage;
    

    public HealthBar healthBar;

    public GameObject pistol;
    public GameObject AmmoDisplay;
    public GameObject AmmoDisplayPanel;
    public GameObject PistolText;

    public GameObject YouDiedPanel;
    public GameObject Crosshair;

    public GameObject MouseSensitivitySettingManager;


    public void Start()
    {
        healthBar.SetMaxHealth(HP);
        deadAndRespawnText.gameObject.SetActive(false);
        deadAndRespawnPanel.SetActive(false);

        firstPersonController = GetComponent<FirstPersonController>();
        bringUpSettings = GetComponent<BringUpSettings>();
        YouDiedPanel.SetActive(false);
        
        
    }

    public void Update()
    {
        if(HP >= 100f)
        {
            HP = 100f;
        }

        if(HP <= 0f)
        {
            HP = 0f;
        }

        if(HP <= 0f && Input.GetKeyDown(KeyCode.F1))
        {
            RestartScene();
        }
    }

    
    public void TakeDamage(float damageAmount)
    {
        HP -= damageAmount;
        
        healthBar.SetHealth(HP);

        if(HP <= 0f)
        {
           print("Player Dead");
           pistol.SetActive(false);
           AmmoDisplay.SetActive(false);
           AmmoDisplayPanel.SetActive(false);
           PistolText.SetActive(false);

           //player.transform.position = respawnPoint.transform.position;
           //player.transform.rotation = respawnPoint.transform.rotation;
           YouDiedPanel.SetActive(true);
           Cursor.lockState = CursorLockMode.Locked;
           Cursor.visible = false;

           Physics.SyncTransforms();

           //HP = 100f;
           healthBar.SetHealth(HP);

           HealthBar.SetActive(false);
           Timer.SetActive(false);
           Crosshair.SetActive(false);
           MouseSensitivitySettingManager.SetActive(false);

           //deadAndRespawnText.gameObject.SetActive(true);
           //deadAndRespawnPanel.SetActive(true);

           firstPersonController.enabled = false;
           bringUpSettings.enabled = false;

           //camera.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
           
           
           //Invoke("HideText", 1f);

           //Invoke("RestartScene", 1f);
        
           

        }
        else
        {
            print("Player Hit");
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("spiketrap"))
        {
            
            TakeDamage(0.1f);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("spiketrap"))
        {
            TakeDamage(0f);
        }
    }

    

    // public void HideText()
    // {
    //     deadAndRespawnText.gameObject.SetActive(false);
    //     deadAndRespawnPanel.SetActive(false);
    // }

    

    

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}

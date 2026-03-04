using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickUp : MonoBehaviour
{
    //public GameObject pickUpMedicKitOB;
    //public GameObject pickUpMedicKitHandleOB;
    public GameObject player;
    public GameObject pickUpText;
    public GameObject cannotPickUpText;
    public GameObject cannotPickUpTextPanel;
    public float addHealth = 25f;
    private float currentHealth;

    //public AudioSource healthPickUpSound;

    //public GameObject screenFX;

    //public bool inReach;

    public float raycastDistance = 1f;

    public LayerMask whatIsMedicKit;

    private Camera mainCam;

    public Color rayColor = Color.red;

    
    public HealthBar healthBar;

    private Player playerHealth;

    private bool _isActive_ = false;


    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Reach")
    //     {
    //         inReach = true;
    //         pickUpText.SetActive(true);

    //     }
    // }

    // void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.tag == "Reach")
    //     {
    //         inReach = false;
    //         pickUpText.SetActive(false);
    //         cannotPickUpText.SetActive(false);
    //     }
    // }

    void Start()
    {
        currentHealth = player.GetComponent<Player>().HP;
        cannotPickUpText.SetActive(false);
        cannotPickUpTextPanel.SetActive(false);
        pickUpText.SetActive(false);

        //screenFX.SetActive(false);

        //inReach = false;
        mainCam = Camera.main;
        playerHealth = GetComponent<Player>();
        
        healthBar.SetMaxHealth(playerHealth.HP);
        
    }

    void Update()
    {
        Ray ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward * raycastDistance, rayColor);

        if (Physics.Raycast(ray, out hit, raycastDistance, whatIsMedicKit))
        {

            if (hit.collider.CompareTag("MedicKit"))
            {

                if (!_isActive_)
                {
                    pickUpText.SetActive(true);
                }

                if (Input.GetButtonDown("Interact"))
                {
                    pickUpText.SetActive(false);
                    _isActive_ = true;
                }
                
            }
            else
            {
                pickUpText.SetActive(false);
                _isActive_ = false;
            }

            
            
            
            // else
            // {
            //     pickUpText.SetActive(false);
            //     cannotPickUpText.SetActive(false);
            // }

            if (hit.collider.CompareTag("MedicKit") && Input.GetButtonDown("Interact") && player.GetComponent<Player>().HP < 100)
            {

            //inReach = false;
            //healthPickUpSound.Play();
            player.GetComponent<Player>().HP += addHealth;
            healthBar.SetHealth(playerHealth.HP += addHealth);
            
            

            

            //screenFX.SetActive(true);
            //pickUpMedicKitOB.GetComponent<BoxCollider>().enabled = false;
            //pickUpMedicKitOB.GetComponent<MeshRenderer>().enabled = false;
            //pickUpMedicKitHandleOB.GetComponent<MeshRenderer>().enabled = false;
            hit.collider.gameObject.SetActive(false);
            pickUpText.SetActive(false);
            //StartCoroutine(TurnScreenFXOFF());

            }
            
            if (hit.collider.CompareTag("MedicKit") && Input.GetButtonDown("Interact") && player.GetComponent<Player>().HP == 100)
            {

            pickUpText.SetActive(false);
            cannotPickUpText.SetActive(true);
            cannotPickUpTextPanel.SetActive(true);

            }

            

        }
        else
        {
            pickUpText.SetActive(false);
            _isActive_ = false;
        }

        if(!Physics.Raycast(ray, out hit, raycastDistance, whatIsMedicKit))
        {
            pickUpText.SetActive(false);
            cannotPickUpText.SetActive(false);
            cannotPickUpTextPanel.SetActive(false);
        }

        

        // if(inReach && Input.GetButtonDown("Interact") && player.GetComponent<Player>().HP < 100)
        // {
        //     inReach = false;
        //     //healthPickUpSound.Play();
        //     player.GetComponent<Player>().HP += addHealth;
        //     //screenFX.SetActive(true);
        //     pickUpOB.GetComponent<BoxCollider>().enabled = false;
        //     pickUpOB.GetComponent<MeshRenderer>().enabled = false;
        //     pickUpText.SetActive(false);
        //     //StartCoroutine(TurnScreenFXOFF());
        // }

        // else if (inReach && Input.GetButtonDown("Interact") && player.GetComponent<Player>().HP == 100)
        // {
        //     pickUpText.SetActive(false);
        //     cannotPickUpText.SetActive(true);
        // }

    }

    // IEnumerator TurnScreenFXOFF()
    // {
    //     yield return new WaitForSeconds(1.25f);
    //     screenFX.SetActive(false);
    //     pickUpOB.SetActive(false);
    // }
}

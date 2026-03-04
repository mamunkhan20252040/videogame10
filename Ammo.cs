using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    //private GameObject theAmmo;
    //public GameObject theAmmo;
    //private GameObject instantiatedTheAmmo;
    private GameObject weaponOB;
    
    private TextMeshProUGUI pickUpText;
    private GameObject pickUpTextGameObject;
    
    //public AudioSource pickUpSound;

    public float ammoBoxAmount;

    //private MeshRenderer meshRenderer;

    
    

    public float raycastDistance = 1f;

    public LayerMask whatIsPistolAmmo;

    private Camera mainCam;

    public Color rayColor = Color.red;

    void Start()
    {
        weaponOB = GameObject.FindWithTag("Pistol");
        GameObject pickUpTextGameObject = GameObject.FindGameObjectWithTag("E");
        pickUpText = pickUpTextGameObject.GetComponent<TextMeshProUGUI>();
        mainCam = Camera.main;
        //theAmmo = this.gameObject;
        //theAmmo = GameObject.FindGameObjectWithTag("PistolAmmo");
        //instantiatedTheAmmo = Instantiate(theAmmo, transform.position, Quaternion.identity);
        //meshRenderer = theAmmo.GetComponent<MeshRenderer>();
    }
   


    void Update()
    {
        

        Ray ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward * raycastDistance, rayColor);

        if (Physics.Raycast(ray, out hit, raycastDistance, whatIsPistolAmmo))
        {

            if (hit.collider.gameObject.CompareTag("PistolAmmo"))
            {

                pickUpText.text = "<sprite name=e>";
                
            }
            

            if (hit.collider.gameObject.CompareTag("PistolAmmo") && Input.GetButtonDown("Interact"))
            {

            weaponOB.GetComponent<Weapon>().magazineSize += ammoBoxAmount;
            //instantiatedTheAmmo.SetActive(false);
            hit.collider.gameObject.SetActive(false);
            //meshRenderer.enabled = false;
            
            
            pickUpText.text = "";
            
            //pickUpSound.Play();

            }
            
           

        }

        if (!Physics.Raycast(ray, out hit, raycastDistance, whatIsPistolAmmo))
        {
            pickUpText.text = "";
        }
        
        
    }


}

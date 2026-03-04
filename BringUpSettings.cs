using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BringUpSettings : MonoBehaviour
{
    public GameObject setting;
    public bool issettingactive;

    public GameObject HealthBar;

    public GameObject Crosshair;

    public Weapon weapon;

    //private FirstPersonController firstPersonController;

    private FirstPersonController firstPersonController;
    public TextMeshProUGUI mouseSensitivityText_;

    public GameObject pistol;
    public GameObject ammoDisplayPanel;
    public GameObject ammoDisplay;
    public GameObject pistolText;

    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (issettingactive == false)
            {
                Pause();
            }

            else
            {
                Resume();
            }
        }
    }

    public void Pause ()
    {
        setting.SetActive(true);
        issettingactive = true;
        //HealthBar.SetActive(false);
        Crosshair.SetActive(false);
        //firstPersonController.enabled = false;
        //if an error occurs make sure to delete and then add your own＜＞(Youtube doesn't allow angled brackets in the comments for some reason)
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        mouseSensitivityText_.text = $"{firstPersonController.mouseSensitivity}";
        weapon.enabled = false;

        pistol.SetActive(false);
        ammoDisplay.SetActive(false);
        ammoDisplayPanel.SetActive(false);
        pistolText.SetActive(false);
    }

    public void Resume ()
    {
        setting.SetActive(false);
        issettingactive = false;
        //HealthBar.SetActive(true);
        Crosshair.SetActive(true);
        //firstPersonController.enabled = true;
        //if an error occurs make sure to delete and then add your own＜＞(Youtube doesn't allow angled brackets in the comments for some reason)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        weapon.enabled = true;

        pistol.SetActive(true);
        ammoDisplay.SetActive(true);
        ammoDisplayPanel.SetActive(true);
        pistolText.SetActive(true);
    }
}

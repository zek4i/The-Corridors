using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlashLight : MonoBehaviour
{
    public GameObject inttext; // Interaction text
    public GameObject flashlight_table; // Flashlight on the table
    public GameObject flashlight_hand; // Flashlight in hand
    public AudioSource pickup;
    private bool interactable;
    private GameObject playerCamera;

    void Start()
    {
        // Find the MainCamera in the scene
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");

        // Initially, the interaction text should be hidden
        inttext.SetActive(false);
        // Ensure the flashlight in hand is initially disabled
        flashlight_hand.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == playerCamera)
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerCamera)
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false);
                interactable = false;
                //play()
                flashlight_hand.SetActive(true); // Enable the flashlight in hand
                flashlight_table.SetActive(false); // Disable the flashlight on the table
            }
        }
    }
}
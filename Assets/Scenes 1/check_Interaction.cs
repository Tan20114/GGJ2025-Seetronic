using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_Interaction : MonoBehaviour
{
    private bool _IscanInteract = false;
    private void OnTriggerEnter(Collider plane)
    {
        if (plane.CompareTag("plane"))
        {
            Debug.Log("Press E to interact");
            _IscanInteract = true;
        }
    }

    private void OnTriggerExit(Collider plane)
    {
        if (plane.CompareTag("plane"))
        {
            Debug.Log("Left interaction zone");
            _IscanInteract = false; 
        }
    }

    private void Update()
    {
        if (_IscanInteract && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interaction triggered!");
        }
    }

}

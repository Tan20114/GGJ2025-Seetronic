using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_Interaction : MonoBehaviour
{
    private bool _IscanInteract = false;
    public bool CanInteract { get { return _IscanInteract; } }
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
        IsInteracted();
    }

    public bool IsInteracted()
    {
        if (_IscanInteract && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interaction triggered!");
            return true;
        }
        else
            return false;
    }

}

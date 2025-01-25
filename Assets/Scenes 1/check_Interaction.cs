using System.Collections;
using UnityEngine;

public class CheckInteraction : MonoBehaviour
{
    public InteractableObject currentInteractable;
    private bool canInteract = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            Debug.Log("Press E to interact");
            currentInteractable = other.GetComponent<InteractableObject>();

            if (currentInteractable != null)
            {
                canInteract = true;
                currentInteractable.CanInteract = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            Debug.Log("Left interaction zone");

            if (currentInteractable != null)
            {
                currentInteractable.CanInteract = false;
                currentInteractable = null;
            }

            canInteract = false;
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            Debug.Log("Interacted");
            currentInteractable.isInteracted = !currentInteractable.isInteracted;
        }
    }
}

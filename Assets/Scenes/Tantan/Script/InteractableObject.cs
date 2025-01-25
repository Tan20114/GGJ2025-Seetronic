using System.Collections;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected Movement mm;

    public bool isInteracted = false;
    public bool CanInteract;

    [SerializeField] private float uiShowTime;

    [SerializeField] GameObject visualInteractable;
    [SerializeField] protected GameObject uiElement;

    protected void Start()
    {
        mm = FindObjectOfType<Movement>();

        uiElement.SetActive(false);
        visualInteractable.SetActive(false);
    }

    protected void Update()
    {
        CanInteractVisualize();
        Interacted();
    }

    private void CanInteractVisualize()
    {
        visualInteractable.SetActive(CanInteract);
    }

    public virtual void Interacted()
    {
        if (isInteracted)
        {
            uiElement.SetActive(true);
            mm.enabled = false;
        }
        else
        {
            uiElement.SetActive(false);
            mm.enabled = true;
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected check_Interaction ci;

    public bool isInteracted = false;

    [SerializeField] private float uiShowTime;

    [SerializeField] GameObject visualInteractable;
    [SerializeField] protected GameObject uiElement;
    private void Start()
    {
        ci = FindAnyObjectByType<check_Interaction>();
    }

    protected void Update()
    {
        Interacted();
        CanInteractVisualize();
    }

    private void CanInteractVisualize()
    {
        if(ci.CanInteract)
        {
            visualInteractable.SetActive(true);
        }
        else
        {
            visualInteractable.SetActive(false);
        }
    }

    public virtual void Interacted()
    {
        if (ci.IsInteracted())
        {
            StartCoroutine(ShowUI());
        }
    }

    protected IEnumerator ShowUI()
    {
        uiElement.SetActive(true);
        yield return new WaitForSeconds(uiShowTime);
        uiElement.SetActive(false);
    }
}

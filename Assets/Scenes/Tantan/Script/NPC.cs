using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObject
{
    [SerializeField] private List<GameObject> speech;
    private int count = 0;

    public override void Interacted()
    {
        if (isInteracted)
        {
            mm.enabled = false;

            // Check if there's more speech and handle interaction with key press
            if (Input.GetKeyDown(KeyCode.A) && count < speech.Count)
            {
                StartCoroutine(Speak(count));
                count++;
            }
        }
        else
        {
            mm.enabled = true;
        }
    }

    private IEnumerator Speak(int index)
    {
        // Activate current speech bubble
        speech[index].SetActive(true);

        // Wait for 3 seconds
        yield return new WaitForSeconds(3);

        // Deactivate the speech bubble
        speech[index].SetActive(false);
    }
}

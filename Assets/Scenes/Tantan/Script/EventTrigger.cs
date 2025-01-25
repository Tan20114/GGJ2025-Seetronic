using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] List<GameObject> lights;
    [SerializeField] GameObject light;
    [SerializeField] GameObject volume;
    [SerializeField] GameObject playerText;

    private void Start()
    {
        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }
        light.SetActive(false);
        volume.SetActive(false);
        playerText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach(GameObject light in lights)
            {
                light.SetActive(false);
            }
            light.SetActive(true);
            volume.SetActive(true);
            StartCoroutine(ShowTxt());
        }
    }

    IEnumerator ShowTxt ()
    {
            playerText.SetActive(true);
        yield return new WaitForSeconds(3f);
        playerText.SetActive(false);
            this.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTemp : MonoBehaviour
{
    private InteractableObject io;

    [SerializeField] List<GameObject> lights;
    [SerializeField] GameObject light;
    [SerializeField] GameObject volume;

    private void Start()
    {
        io = GetComponent<InteractableObject>();
    }

    public void Update()
    {
        if (io.isInteracted)
        {
            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
            light.SetActive(false);
            volume.SetActive(false);
        }
    }
}

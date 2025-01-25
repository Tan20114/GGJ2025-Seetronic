using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTemp : MonoBehaviour
{
    private InteractableObject io;

    [SerializeField] List<GameObject> lights;
    [SerializeField] GameObject light;
    [SerializeField] GameObject volume;
    [SerializeField] GameObject triggerBox;

    private void Start()
    {
        io = GetComponent<InteractableObject>();
    }

    public void Update()
    {
        if (io.isInteracted && ScoreManager.totalScore == 6)
        {
            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
            light.SetActive(false);
            volume.SetActive(false);
            triggerBox.SetActive(true);
        }
    }
}

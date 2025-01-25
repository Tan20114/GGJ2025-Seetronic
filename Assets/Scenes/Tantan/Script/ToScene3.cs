using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToScene3 : MonoBehaviour
{
    SceneLoader sl;

    private void Start()
    {
        sl =FindAnyObjectByType<SceneLoader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(sl.LoadScene(3));
        }
    }
}

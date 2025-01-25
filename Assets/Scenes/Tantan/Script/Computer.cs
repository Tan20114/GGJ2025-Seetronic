using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : InteractableObject
{
    SceneLoader sl;
    void Start()
    {
        sl = FindAnyObjectByType<SceneLoader>();
    }
    public override void Interacted()
    {
        if (isInteracted)
        {
            StartCoroutine(sl.LoadScene(5));
        }
    }
}
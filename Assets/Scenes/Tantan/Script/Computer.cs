using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : InteractableObject
{
    SceneLoader sl;
    public override void Interacted()
    {

        void Start()
        {
            sl = FindObjectOfType<SceneLoader>();
        }

        if (isInteracted)
        {
            StartCoroutine(sl.LoadScene(5));
        }
    }
}
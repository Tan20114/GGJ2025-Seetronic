using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1Minigame : InteractableObject
{
    SceneLoader sl;

    private void Start()
    {
        sl = FindAnyObjectByType<SceneLoader>();
    }

    public override void Interacted()
    {
        if (isInteracted)
        {
            StartCoroutine(sl.LoadScene(4));
        }
    }
}

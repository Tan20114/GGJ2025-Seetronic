using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Day1Trigger : MonoBehaviour
{
    [SerializeField] GameObject txt;

    private void Awake()
    {
        // Restore the finishPewPew state (optional: log it)
        Debug.Log($"FinishPewPew state: {BackToScene1.finishPewPew}");
    }

    private void Start()
    {
        if (BackToScene1.finishPewPew)
        {
            txt.SetActive(true);
        }
    }
}

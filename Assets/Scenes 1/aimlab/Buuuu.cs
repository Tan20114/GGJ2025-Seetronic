using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Buuuu : MonoBehaviour
{
    private targetspawn ts;
    public int scoreValue = 10;
    void Start()
    {
        ts = FindAnyObjectByType<targetspawn>();
    }
    void OnMouseDown()
    {
        ts.gameObjects.Remove(gameObject);
        Destroy(gameObject);
        GameManager.Instance.AddScore(scoreValue);
    }
    
}

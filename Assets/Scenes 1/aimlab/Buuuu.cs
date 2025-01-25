using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Buuuu : MonoBehaviour
{
    private targetspawn ts;
    void Start()
    {
        ts = GameObject.Find("Targetspawn").GetComponent<targetspawn>();
    }

    // Start is called before the first frame update
    void OnMouseDown()
    {
        ts.gameObjects.Remove(gameObject);
        Destroy(gameObject);
    }
}

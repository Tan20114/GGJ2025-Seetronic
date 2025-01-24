using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public int scoreValue = 10;
    public float lifetime = 3f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnMouseDown()
    {
        GameManager.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }
}

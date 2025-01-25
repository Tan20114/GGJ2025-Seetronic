using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camer : MonoBehaviour
{
    [SerializeField]private Vector3 offset = new Vector3(0f , 0f , -10f);
    public float smoothTime = 0.01f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;

    void Update()
    {
        if(target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position,targetPosition,ref velocity , smoothTime);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    Collider collider;

    Vector3 firstPos;

    private void Start()
    {
        base.Start();
        collider = GetComponent<Collider>();
        firstPos = this.transform.position;
    }

    public override void Interacted()
    {
        if (isInteracted)
        {
            Vector3 targetPosition = firstPos + new Vector3(1, 0, 1);
            collider.isTrigger = true;
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            this.transform.position = targetPosition;
        }
        else
        {
            collider.isTrigger = false;
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
            this.transform.position = firstPos;
        }
    }
}
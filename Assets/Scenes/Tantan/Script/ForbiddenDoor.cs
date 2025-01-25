using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForbiddenDoor : InteractableObject
{
    camer c;

    [SerializeField] Transform player;
    [SerializeField] Transform upperDoor;
    [SerializeField] Transform lowerDoor;

    private void Start()
    {
        c = FindAnyObjectByType<camer>();
    }

    public override void Interacted()
    {
        if (isInteracted)
        {
            c.smoothTime = 2f;
            isInteracted = false;
            player.position = new Vector3(lowerDoor.position.x, lowerDoor.position.y, lowerDoor.position.z);
        }
    }
}

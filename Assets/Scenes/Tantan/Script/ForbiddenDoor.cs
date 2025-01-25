using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForbiddenDoor : InteractableObject
{
    [SerializeField] Transform player;
    [SerializeField] Transform upperDoor;
    [SerializeField] Transform lowerDoor;

    public override void Interacted()
    {
        if (isInteracted)
        {
            isInteracted = false;
            player.position = new Vector3(lowerDoor.position.x, lowerDoor.position.y, lowerDoor.position.z);
        }
    }
}

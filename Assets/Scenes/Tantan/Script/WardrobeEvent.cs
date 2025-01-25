using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeEvent : MonoBehaviour
{
    NPC npc;

    private void Awake()
    {
        npc = GetComponent<NPC>();
    }

    // Start is called before the first frame update
    void Start()
    {
        npc.enabled =false;
    }

    // Update is called once per frame
    void Update()
    {
        if(BackToScene1.finishPewPew)
        {
            npc.enabled = true;
        }
    }
}

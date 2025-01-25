using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeEvent : MonoBehaviour
{
    NPC npc;
    SceneLoader sl;

    private void Awake()
    {
        npc = GetComponent<NPC>();
        sl = FindAnyObjectByType<SceneLoader>();
    }

    // Start is called before the first frame update
    void Start()
    {
        npc.enabled =false;
    }
    bool isTrigger = false;
    // Update is called once per frame
    void Update()
    {
        if(BackToScene1.finishPewPew)
        {
            npc.enabled = true;
        }

        if (npc.count >= npc.speech.Count && !isTrigger)
        {
            isTrigger = true;
            StartCoroutine(sl.LoadScene(2));
        }
    }
}

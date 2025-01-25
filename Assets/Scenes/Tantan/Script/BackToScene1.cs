using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToScene1 : MonoBehaviour
{
    SceneLoader sl;

    private bool hasTriggeredSceneLoad = false;

    private void Start()
    {
        sl = FindAnyObjectByType<SceneLoader>(); 
    }
    /*void Update()
    {
        if (GameManager.Instance.isEnd && !hasTriggeredSceneLoad)
        {
            hasTriggeredSceneLoad = true;
            Time.timeScale = 1;
            StartCoroutine(sl.LoadScene(1));
        }
    }*/
}

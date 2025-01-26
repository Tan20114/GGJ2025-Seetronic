using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    SceneLoader sl;
    [SerializeField] Animator a;
    // Start is called before the first frame update
    void Start()
    {
        sl = FindAnyObjectByType<SceneLoader>();
        StartCoroutine(EndingScene());
    }

    IEnumerator EndingScene()
    {
        yield return new WaitForSeconds(4.0f);
        a.SetTrigger("Ending");
    }
}

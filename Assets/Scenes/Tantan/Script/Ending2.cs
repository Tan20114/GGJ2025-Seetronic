using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending2 : MonoBehaviour
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
        yield return new WaitForSeconds(8.0f);
        a.SetTrigger("ToLast");
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(sl.LoadScene(0));
    }
}

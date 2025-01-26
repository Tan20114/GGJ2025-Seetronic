using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tomenu : MonoBehaviour
{
    SceneLoader sl;

    [SerializeField] Button goBack;

    private void Start()
    {
        sl = FindAnyObjectByType<SceneLoader>();
        goBack.onClick.AddListener(GoBack);
    }

    void GoBack()
    {
        StartCoroutine(sl.LoadScene(0));
    }
}

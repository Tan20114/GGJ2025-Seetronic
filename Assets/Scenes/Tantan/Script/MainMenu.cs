using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    SceneLoader sl;

    [SerializeField] Button startButt;
    [SerializeField] Button exitButt;

    void Start()
    {
        sl = FindAnyObjectByType<SceneLoader>();

        startButt.onClick.AddListener(StartGame);
        exitButt.onClick.AddListener(ExitGame);
    }

    void StartGame()
    {
        StartCoroutine(sl.LoadScene(1));
    }


    void ExitGame()
    {
        StartCoroutine(sl.ExitGame());
    }
}

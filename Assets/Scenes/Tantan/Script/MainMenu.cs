using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    SceneLoader sl;

    [SerializeField] Button startButt;
    [SerializeField] Button exitButt;
    [SerializeField] Button creditButt;

    void Start()
    {
        sl = FindAnyObjectByType<SceneLoader>();

        startButt.onClick.AddListener(StartGame);
        exitButt.onClick.AddListener(ExitGame);
        creditButt.onClick.AddListener(ShowCredit);
    }

    void StartGame()
    {
        StartCoroutine(sl.LoadScene(1));
    }


    void ExitGame()
    {
        StartCoroutine(sl.ExitGame());
    }

    void ShowCredit()
    {
        StartCoroutine(sl.LoadScene(6));
    }
}

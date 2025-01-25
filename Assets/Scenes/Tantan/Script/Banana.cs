using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Banana : InteractableObject
{
    [SerializeField] Button banana;
    [SerializeField] private TextMeshProUGUI scoreTxt;
    private int score = 0;

    private void Awake()
    {
        GetData();
    }

    private void Start()
    {
        base.Start();
        banana.onClick.AddListener(AddScore);
    }

    private void Update()
    {
        base.Update();
        scoreTxt.text = $"{score}";
    }

    public override void Interacted()
    {
        base.Interacted();
    }

    void AddScore()
    {
        score++;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("BananaScore", score);
        PlayerPrefs.Save();
    }

    public int GetData()
    {
        int scr;

        if (PlayerPrefs.HasKey("BananaScore"))
        {
            scr = PlayerPrefs.GetInt("BananaScore");
        }
        else
            scr = 0;

        return scr;
    }
}

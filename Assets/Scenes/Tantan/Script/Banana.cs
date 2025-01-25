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
}

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text scoreText;
    public Text timerText;

    private int score = 0;
    private float gameTime = 60f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        gameTime -= Time.deltaTime;
        timerText.text = $"เวลา: {Mathf.Max(0, Mathf.CeilToInt(gameTime))}";

        if (gameTime <= 0)
        {
            EndGame();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = $"คะแนน: {score}";
    }

    private void EndGame()
    {
        Debug.Log("เกมจบ! คะแนนรวม: " + score);
        Time.timeScale = 0;
    }
}

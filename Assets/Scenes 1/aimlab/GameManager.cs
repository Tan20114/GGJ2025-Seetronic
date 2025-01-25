using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI EndText;

    private int score = 0;
    private float gameTime = 15f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        EndText.gameObject.SetActive(false);
    }

    private void Update()
    {
        gameTime -= Time.deltaTime;
        timerText.text = $"Time : {Mathf.Max(0, Mathf.CeilToInt(gameTime))}";

        if (gameTime <= 0)
        {
            EndGame();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = $"Score : {score}";
    }

    public bool EndGame()
    {
        bool isEnd = true;

        EndText.gameObject.SetActive(true);
        Debug.Log("End Score: " + score);
        Time.timeScale = 0;
        EndText.text = $"End Game \n Final Score : {score}";

        return isEnd;
    }
}

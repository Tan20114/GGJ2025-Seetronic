using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private SceneLoader sl;

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
        sl = FindAnyObjectByType<SceneLoader>();
    }

    bool sceneTrigger = false;

    private void Update()
    {
        gameTime -= Time.deltaTime;
        timerText.text = $"Time : {Mathf.Max(0, Mathf.CeilToInt(gameTime))}";

        if (gameTime <= 0 && !sceneTrigger)
        {
            sceneTrigger = true;
            EndGame();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = $"Score : {score}";
    }

    bool isEnd = false;

    public void EndGame()
    {
        isEnd = true;
        EndText.gameObject.SetActive(true);
        Debug.Log("End Score: " + score);
        EndText.text = $"End Game \n Final Score : {score}";
        StartCoroutine(sl.LoadScene(1));
    }
}

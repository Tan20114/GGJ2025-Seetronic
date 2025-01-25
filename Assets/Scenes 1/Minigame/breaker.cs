using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class breaker : MonoBehaviour
{
    public Button button;
    public Color normalColor = Color.red;
    public Color pressedColor = Color.yellow;
    private Image buttonImage;


    public TMP_Text buttonText;
    public string normalText = "off";
    public string pressedText = "on";

    void Start()
    {
        buttonImage = button.GetComponent<Image>();

        if (buttonImage != null)
        {
            buttonImage.color = normalColor;
        }
        button.onClick.AddListener(ChangeColor);
        if (buttonText != null)
        {
            buttonText.text = normalText;
        }
        button.onClick.AddListener(ChangeText);
    }

    void ChangeColor()
    {
        if (buttonImage.color == normalColor)
        {
            buttonImage.color = pressedColor;
            ScoreManager.totalScore++;
            Debug.Log($"{ScoreManager.totalScore}");
        }
        else
        {
            buttonImage.color = normalColor;
            ScoreManager.totalScore --;
            Debug.Log($"{ScoreManager.totalScore}");
        }
        if(ScoreManager.totalScore == 6)
        {
            Debug.Log("ครบละไอสัส");
        }
    }
    void ChangeText()
    {
        if (buttonText.text == normalText)
        {
            buttonText.text = pressedText;
        }
        else
        {
            buttonText.text = normalText;
        }
    }
}


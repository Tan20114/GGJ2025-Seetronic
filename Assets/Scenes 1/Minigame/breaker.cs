using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class breaker : MonoBehaviour
{
    public Button button;
    public Sprite normalColor;       // This is the sprite when the button is in its "normal" state
    public Sprite pressedColor;      // This is the sprite when the button is in the "pressed" state
    private Image buttonImage;

    public TMP_Text buttonText;
    public string normalText = "off";
    public string pressedText = "on";
    public Sprite newNormalSprite;   // This is the sprite that should be used at the start

    void Start()
    {
        buttonImage = button.GetComponent<Image>();

        // Set the initial button sprite to newNormalSprite.
        if (buttonImage != null)
        {
            buttonImage.sprite = normalColor; // Set the sprite initially
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
        // Toggle button image between normal and pressed state
        if (buttonImage.sprite == normalColor)
        {
            buttonImage.sprite = pressedColor;
            ScoreManager.totalScore++;
            Debug.Log($"{ScoreManager.totalScore}");
        }
        else
        {
            buttonImage.sprite = normalColor;
            ScoreManager.totalScore--;
            Debug.Log($"{ScoreManager.totalScore}");
        }

        // Check score condition
        if (ScoreManager.totalScore == 6)
        {
            Debug.Log("ครบละไอสัส");
        }
    }

    void ChangeText()
    {
        // Toggle button text between "off" and "on"
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

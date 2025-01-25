using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ChatBuuble : MonoBehaviour
{
    private Coroutine typingCoroutine;
    private Coroutine shakeCoroutine;
    private Coroutine bounceCoroutine;
    #region Variables
    [Header("Don't touch me")]
    [SerializeField] SpriteRenderer sr;
    [SerializeField] TextMeshPro text;
    [SerializeField] Animator animPlayer;
    [Header("Animation")]
    [SerializeField] float animTime = 1f;
    [Header("Text Parameter")]
    [SerializeField, MaxLength(11)] string txt;
    [SerializeField] float typeSpeed = 0.05f;
    [SerializeField] float loopInterval = 2f;
    [SerializeField] float paddingVal;
    [Header("Shake Parameter")]
    [SerializeField] private float shakeMagnitude = 2f;
    [SerializeField] private float shakeFrequency = 0.1f;
    [Header("Bounce Parameter")]
    [SerializeField] private float bounceMagnitude = 5f;
    [SerializeField] private float bounceFrequency = 2f;
    [Header("Effect toggle")]
    [SerializeField] private bool shakeEffect = true;
    [SerializeField] private bool bounceEffect = true;
    [SerializeField] private bool loopTyping = true;
    #endregion

    private void OnEnable()
    {
        StartCoroutine(StartAnim());
        Setup(txt);
    }

    private void OnDisable()
    {
        this.transform.localScale = new Vector3(0, 0, 0);
    }

    IEnumerator StartAnim()
    {
        animPlayer.SetTrigger("ChatBubble");
        yield return new WaitForSeconds(animTime);
    }

    #region Text part
    void Setup(string txt)
    {
        StartTyping(txt);
        text.ForceMeshUpdate();

        Vector2 textSize = text.GetRenderedValues(false);

        Vector2 padding = new Vector2(paddingVal, paddingVal);

        Vector3 newScale = new Vector3(
            (textSize.x + paddingVal) / sr.sprite.bounds.size.x,
            (textSize.y + paddingVal) / sr.sprite.bounds.size.y,
            1f
        );

        sr.transform.localScale = newScale;

        text.alignment = TextAlignmentOptions.Left;

        sr.transform.localPosition = new Vector3(
            sr.transform.localPosition.x - (textSize.x + padding.x) / 2,
            sr.transform.localPosition.y,
            sr.transform.localPosition.z
        );
    }



    public void StartTyping(string text)
    {
        txt = text;

        // Stop any currently running coroutine
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        text.text = ""; // Clear text initially
        text.ForceMeshUpdate(); // Update the text mesh

        // Start typing the text character by character
        for (int i = 0; i < txt.Length; i++)
        {
            text.text += txt[i];
            text.ForceMeshUpdate(); // Force update after each character

            // Dynamically adjust the background size
            UpdateBackgroundSize();

            yield return new WaitForSeconds(typeSpeed);
        }

        // Reset effects after typing
        if (shakeEffect && shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
            shakeCoroutine = null;
        }
        if (bounceEffect && bounceCoroutine != null)
        {
            StopCoroutine(bounceCoroutine);
            bounceCoroutine = null;
        }

        ResetEffect();
        StartEffect();

        if (loopTyping)
        {
            yield return new WaitForSeconds(loopInterval);
            typingCoroutine = StartCoroutine(TypeText());
        }
    }

    private void UpdateBackgroundSize()
    {
        Vector2 textSize = text.GetRenderedValues(false);
        Vector2 padding = new Vector2(paddingVal, paddingVal);

        Vector3 newScale = new Vector3(
            (textSize.x + paddingVal) / sr.sprite.bounds.size.x,
            5f,
            1f
        );

        Vector3 center = sr.transform.position - (sr.bounds.size * 0.5f);
        text.transform.position = new Vector3(center.x/2, text.transform.position.y, text.transform.position.z);
        sr.transform.localScale = newScale;
    }

    void ResetEffect()
    {
        if (shakeEffect && shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
            shakeCoroutine = null;
        }
        if (bounceEffect && bounceCoroutine != null)
        {
            StopCoroutine(bounceCoroutine);
            bounceCoroutine = null;
        }
    }

    void StartEffect()
    {
        if (shakeEffect)
            shakeCoroutine = StartCoroutine(ShakeAllCharacters());
        if (bounceEffect)
            bounceCoroutine = StartCoroutine(BounceAllCharacters());
    }

    private IEnumerator ShakeAllCharacters()
    {
        TMP_TextInfo textInfo = text.textInfo;

        while (true) // Continuous shaking
        {
            text.ForceMeshUpdate();
            textInfo = text.textInfo;

            for (int i = 0; i < textInfo.characterCount; i++)
            {
                // Skip invisible characters
                if (!textInfo.characterInfo[i].isVisible)
                    continue;

                Vector3[] vertices = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices;
                int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                // Apply random shake to each vertex of the character
                for (int j = 0; j < 4; j++)
                {
                    Vector3 originalPosition = vertices[vertexIndex + j];
                    vertices[vertexIndex + j] = originalPosition + new Vector3(
                        Random.Range(-shakeMagnitude, shakeMagnitude),
                        Random.Range(-shakeMagnitude, shakeMagnitude),
                        0);
                }
            }

            // Apply the modified vertex positions back to the mesh
            text.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);

            yield return new WaitForSeconds(shakeFrequency);
        }
    }

    private IEnumerator BounceAllCharacters()
    {
        TMP_TextInfo textInfo = text.textInfo;
        float time = 0f;

        while (true) // Continuous bouncing
        {
            text.ForceMeshUpdate();
            textInfo = text.textInfo;

            for (int i = 0; i < textInfo.characterCount; i++)
            {
                // Skip invisible characters
                if (!textInfo.characterInfo[i].isVisible)
                    continue;

                Vector3[] vertices = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices;
                int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                // Calculate vertical offset using a sine wave
                float offset = Mathf.Sin((time + i) * bounceFrequency) * bounceMagnitude;

                for (int j = 0; j < 4; j++)
                {
                    Vector3 originalPosition = vertices[vertexIndex + j];
                    vertices[vertexIndex + j] = new Vector3(originalPosition.x, originalPosition.y + offset, originalPosition.z);
                }
            }

            // Apply the modified vertex positions back to the mesh
            text.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);

            time += Time.deltaTime;
            yield return null; // Wait for the next frame
        }
    }
    #endregion
}

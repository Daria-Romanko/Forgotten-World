using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalSlideShow : MonoBehaviour
{
    public GameObject panel;
    public GameObject finalPanel;
    public Image image;
    public GameObject background;
    public Sprite[] sprites;
    public float fadeDuration;
    public float displayTime;
    public TMP_Text[] texts;

    private int currentSprite = 0;

    public void PlaySlideShow()
    {
        panel.gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().BlockPlayerMovement();
        StartCoroutine(ShowSlides());
    }

    private IEnumerator ShowSlides()
    {
        yield return new WaitForSeconds(fadeDuration);

        DialogueManager.BarkString("Что-то должно произойти...", GameObject.FindGameObjectWithTag("Player").transform);

        yield return FadeImage(true);
        yield return FadeImage(false);
        yield return new WaitForSeconds(fadeDuration);

        DialogueManager.BarkString("Как-то мне нехорошо...", GameObject.FindGameObjectWithTag("Player").transform);

        yield return FadeImage(true);
        yield return FadeImage(false);
        yield return new WaitForSeconds(fadeDuration);

        yield return FadeImage(true);
        background.gameObject.SetActive(true);
        image.sprite = sprites[currentSprite];
        DialogueManager.BarkString("Темно... так темно...", GameObject.FindGameObjectWithTag("Player").transform);
        yield return new WaitForSeconds(displayTime);
        yield return FadeImage(false);

        currentSprite++;

        image.sprite = sprites[currentSprite];
        yield return FadeImage(true);
        DialogueManager.BarkString("Я что-то вижу...", GameObject.FindGameObjectWithTag("Player").transform);
        yield return new WaitForSeconds(displayTime);
        yield return FadeImage(false);
        
        currentSprite++;

        DialogueManager.BarkString("...", GameObject.FindGameObjectWithTag("Player").transform);

        yield return new WaitForSeconds(displayTime);
        yield return MoveImage(false,1f);

        image.sprite = sprites[currentSprite];

        yield return FadeImage(true);

        yield return new WaitForSeconds(displayTime / 2);

        yield return MoveImage(true,fadeDuration*4);

        for(int i = 0; i < 2; i++)
        {
            yield return BlinkingText();
        }
        
        currentSprite++;

        image.sprite = sprites[currentSprite];

        yield return new WaitForSeconds(displayTime);

        currentSprite++;

        yield return FadeImage(false);

        image.sprite = sprites[currentSprite];
        yield return new WaitForSeconds(displayTime);

        yield return FadeImage(true);

        currentSprite++;

        image.sprite = sprites[currentSprite];
        yield return new WaitForSeconds(displayTime);

        DialogueManager.BarkString("Это был всего лишь сон...", GameObject.FindGameObjectWithTag("Player").transform);

        yield return new WaitForSeconds(displayTime * 2);

        finalPanel.gameObject.SetActive(true);
    }

    private IEnumerator FadeImage(bool fadeIn)
    {
        float elapsedTime = 0f;
        float startAlpha = fadeIn ? 0f : 1f;
        float targetAlpha = fadeIn ? 1f : 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            Color newColor = image.color;
            newColor.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            image.color = newColor;

            yield return null;
        }
    }

    private IEnumerator MoveImage(bool zoomIn, float t)
    {
        float elapsedTime = 0f;
        Vector3 startScale = zoomIn ? new Vector3(2f, 2f, 1f) : new Vector3(1f, 1f, 1f);
        Vector3 targetScale = zoomIn ? new Vector3(1f, 1f, 1f) : new Vector3(2f, 2f, 1f);

        while (elapsedTime < t) 
        {
            elapsedTime += Time.deltaTime;
            image.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / (t));

            yield return null;
        }
    }

    private IEnumerator BlinkingText()
    {
        for(int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
        }

        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(0.5f);

        yield return null;
    }
}

using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
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
        yield return FadeImage(false);
        yield return new WaitForSeconds(fadeDuration);

        while (currentSprite < sprites.Length)
        {
            yield return FadeImage(true);

            background.gameObject.SetActive(true);

            image.sprite = sprites[currentSprite];

            if (currentSprite == 0)
            {
                DialogueManager.BarkString("Темно... так темно...", GameObject.FindGameObjectWithTag("Player").transform);
            }
            if(currentSprite == 1)
            {
                DialogueManager.BarkString("Я что-то вижу...", GameObject.FindGameObjectWithTag("Player").transform);
            }

            yield return new WaitForSeconds(displayTime);

            if(currentSprite != 5)
            {
                yield return FadeImage(false);
            }
       
            currentSprite++;
        }

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
}

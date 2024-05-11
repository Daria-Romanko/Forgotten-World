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
    public float fadeDuration = 5f;
    public float displayTime = 20f;

    private int currentSprite = 0;

    public void PlaySlideShow()
    {
        panel.gameObject.SetActive(true);
        StartCoroutine(ShowSlides());
    }

    private IEnumerator ShowSlides()
    {
        yield return new WaitForSeconds(10f);

        while (currentSprite < sprites.Length)
        {
            yield return FadeImage(true);

            background.gameObject.SetActive(true);

            image.sprite = sprites[currentSprite];

            if (currentSprite == 1)
            {
                DialogueManager.Bark("FinalBark1", GameObject.FindGameObjectWithTag("Player").transform);
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

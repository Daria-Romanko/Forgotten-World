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

    public MusicController musicController;
    public AudioClip finalTrack;

    
    public void PlaySlideShow()
    {
        panel.gameObject.SetActive(true);
        musicController.Stop();
        StartCoroutine(ShowSlides());
    }

    private IEnumerator ShowSlides()
    {
        yield return new WaitForSeconds(fadeDuration);

        DialogueManager.BarkString("���-�� ������ ���������...", GameObject.FindGameObjectWithTag("Player").transform);

        yield return FadeImage(true);
        yield return FadeImage(false);
        yield return new WaitForSeconds(fadeDuration);

        DialogueManager.BarkString("���-�� ��� ��������...", GameObject.FindGameObjectWithTag("Player").transform);

        yield return FadeImage(true);
        yield return FadeImage(false);
        yield return new WaitForSeconds(fadeDuration);

        yield return FadeImage(true);
        background.gameObject.SetActive(true);
        image.sprite = sprites[0];
        DialogueManager.BarkString("�����... ��� �����...", GameObject.FindGameObjectWithTag("Player").transform);
        yield return new WaitForSeconds(displayTime);
        yield return FadeImage(false);

        image.sprite = sprites[1];
        yield return FadeImage(true);
        DialogueManager.BarkString("� ���-�� ����...", GameObject.FindGameObjectWithTag("Player").transform);
        yield return new WaitForSeconds(displayTime);
        yield return FadeImage(false);
        
        DialogueManager.BarkString("...", GameObject.FindGameObjectWithTag("Player").transform);

        yield return MoveImage(false,5f);

        image.sprite = sprites[2];

        musicController.StartCoroutine(musicController.PlayTrack(finalTrack));

        yield return FadeImage(true);

        yield return new WaitForSeconds(displayTime / 2);

        yield return MoveImage(true,fadeDuration*4);

        for(int i = 0; i < 2; i++)
        {
            yield return BlinkingText();
        }
        
        image.sprite = sprites[3];

        yield return new WaitForSeconds(displayTime);

        yield return FadeImage(false);

        image.sprite = sprites[4];

        yield return FadeImage(true);

        image.sprite = sprites[5];
        yield return new WaitForSeconds(displayTime);

        DialogueManager.BarkString("��� ��� ����� ���� ���...", GameObject.FindGameObjectWithTag("Player").transform);

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

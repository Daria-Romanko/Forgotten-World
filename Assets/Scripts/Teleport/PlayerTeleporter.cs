using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.CinemachineFreeLook;

public class PlayerTeleporter : MonoBehaviour
{
    private GameObject currentTeleporter;
    private bool isTeleporting;
    public Image alphaImage;
    public float fadeDuration = 1.5f;
    public GameObject hint;
    public Canvas canvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null && !isTeleporting)
            {
                hint.SetActive(true);
                
                StartCoroutine(Teleport());
            }
        }
    }

    private IEnumerator Teleport()
    {
        hint.SetActive(false);

        isTeleporting = true;

        alphaImage.gameObject.SetActive(true);

        SetAlpha(0f);

        float timer = 0f;

        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            SetAlpha(alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);

        transform.position = currentTeleporter.GetComponent<Teleporter>().GetTransform().position;
        currentTeleporter.GetComponent<Teleporter>().camera1.Priority = 0;
        currentTeleporter.GetComponent<Teleporter>().camera2.Priority = 10;

        timer = 0f;

        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            SetAlpha(alpha);
            timer += Time.deltaTime;
            yield return null;

        }
        alphaImage.gameObject.SetActive(false);

        currentTeleporter = null;

        isTeleporting = false;
    }

    private void SetAlpha(float alpha)
    {
        Color imageColor = alphaImage.color;
        imageColor.a = alpha;
        alphaImage.color = imageColor;

        Color textColor = alphaImage.color;
        textColor.a = alpha;
        alphaImage.color = textColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            hint.SetActive(true);
            string locationName = collision.GetComponent<Teleporter>().locationName;
            hint.GetComponentInChildren<TextMeshProUGUI>().text = locationName;

            LateUpdate();

            currentTeleporter = collision.gameObject;
        }
    }

    private void LateUpdate()
    {
        var rt = hint.GetComponent<RectTransform>();
        var screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, this.transform.position);
        screenPoint.y += 550f;
        var canvasRT = canvas.GetComponent<RectTransform>();
        rt.anchoredPosition = screenPoint - canvasRT.sizeDelta / 2f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            //if (collision == currentTeleporter)
            //{
                currentTeleporter = null;
            //}
            hint.SetActive(false);
        }
    }

}

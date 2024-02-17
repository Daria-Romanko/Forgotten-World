using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeleporter : MonoBehaviour
{
    private GameObject currentTeleporter;
    private bool isTeleporting;
    public Image alphaImage;
    public float fadeDuration = 1.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null && !isTeleporting)
            {
                StartCoroutine(Teleport());
            }
        }
    }

    private IEnumerator Teleport()
    {
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
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if(collision == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }

}

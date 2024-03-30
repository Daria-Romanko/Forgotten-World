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
    public bool isTeleporting;
    public Image alphaImage;
    public float fadeDuration = 0.5f;
    public GameObject hint;
    public Canvas canvas;

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null && !isTeleporting)
            {
                playerController.BlockPlayerMovement();
                StartCoroutine(Teleport());
            }
        }
    }

    private IEnumerator Teleport()
    {
        hint.SetActive(false);
        isTeleporting = true;

        currentTeleporter.gameObject.GetComponent<Teleporter>().PlayAudioClip();

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
      
        DoTeleport();

        timer = 0f;

        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            SetAlpha(alpha);
            timer += Time.deltaTime;
            yield return null;

        }
        alphaImage.gameObject.SetActive(false);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position, 1f);

        foreach (Collider2D collider in colliders)
        {
            OnTriggerEnter2D(collider);
        }


        isTeleporting = false;
        hint.SetActive(true);
        playerController.UnblockPlayerMovement();
    }

    private void DoTeleport()
    {      
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetTransform().position;
        currentTeleporter.GetComponent<Teleporter>().camera1.Priority = 0;
        currentTeleporter.GetComponent<Teleporter>().camera2.Priority = 10;
    }

    public void PauseSFX()
    {
        currentTeleporter.gameObject.GetComponent<Teleporter>().audioSource.Pause();
    }

    public void UnPauseSFX()
    {
        currentTeleporter.gameObject.GetComponent<Teleporter>().audioSource.UnPause();
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
        if (collision.CompareTag("Teleporter") && collision.gameObject != currentTeleporter)
        {
            string locationName = collision.GetComponent<Teleporter>().locationName;
            hint.GetComponentInChildren<TextMeshProUGUI>().text = locationName;
            hint.SetActive(true);

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

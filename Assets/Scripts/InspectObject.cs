using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InspectObject : MonoBehaviour
{
    public Button button;
    public GameObject hint;

    private bool inspected = false;

    public void Inspect()
    {
        if (!inspected)
        {
            inspected = true;
            button.gameObject.SetActive(true);
        }
    }   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !inspected)
        {
            hint.SetActive(true);
            hint.GetComponentInChildren<TextMeshProUGUI>().text = "Осмотреть";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !inspected)
        {
            hint.SetActive(false);
        }
    }

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 1f);

        if (inspected) return;

        if (collider.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Inspect();
            hint.SetActive(false);

            DialogueLua.SetVariable("InventoryReceived", true);
            DialogueManager.Bark("CarBark", GameObject.FindGameObjectWithTag("Player").transform);
        }

    }

}

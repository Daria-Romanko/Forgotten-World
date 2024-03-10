using PixelCrushers.DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimpleLock : MonoBehaviour
{
    public bool interactable = true;
    public GameObject lockPanel;
    public TMP_Text[] text;

    public string password;
    public string[] lockCharacterChoices;
    public int[] _lockCharacterNumber;
    public string _insertedPassword;

    public GameObject hint;

    private PlayerController playerController;
    bool playerInColliderFlag = false;

    public void Start()
    {
        _lockCharacterNumber = new int[password.Length];
        UpdateUI();
        playerController = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        if (playerInColliderFlag && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && lockPanel.activeSelf)
        {
            StopInteract();
        }
    }

    public void ChangeInsertedPassword(int number)
    {
        _lockCharacterNumber[number]++;
        if (_lockCharacterNumber[number] >= lockCharacterChoices[number].Length) 
        {
            _lockCharacterNumber[number] = 0;
        }
        CheckPassword();
        UpdateUI();
    }

    private void UpdateUI()
    {
        int len = text.Length;
        for(int i = 0; i < len; i++)
        {
            text[i].text = lockCharacterChoices[i][_lockCharacterNumber[i]].ToString();
        }
    }

    private void Unlock()
    {
        interactable = false;
        StopInteract();
        Debug.Log("unblocked");
    }

    private void CheckPassword()
    {
        int pass_len = password.Length;
        _insertedPassword = "";
        for (int i = 0; i < pass_len; i++)
        {
            _insertedPassword += lockCharacterChoices[i][_lockCharacterNumber[i]].ToString();
        }
        if (password == _insertedPassword)
        {
            Unlock();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && interactable)
        {
            hint.SetActive(true);
            hint.GetComponentInChildren<TextMeshProUGUI>().text = "Осмотреть";
            playerInColliderFlag = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hint.SetActive(false);
            playerInColliderFlag = false;
        }
    }

    public void Interact()
    {
        if(interactable)
        {
            lockPanel.SetActive(true);
            hint.SetActive(false);
            playerController.BlockPlayerMovement();
        }
    }

    public void StopInteract()
    {
        lockPanel.SetActive(false);
        if (!interactable)
        {
            hint.SetActive(false);
        }
        else
        {
            hint.SetActive(true);
        }
        playerController.UnblockPlayerMovement();
    }
}

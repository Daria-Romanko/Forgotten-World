using Inventory2.Model;
using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FoodMachine : MonoBehaviour
{
    public GameObject hint;

    public InventoryItem item;
    public InventoryItem coin;

    public InventorySO inventory;

    bool playerInColliderFlag = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hint.SetActive(true);
            hint.GetComponentInChildren<TextMeshProUGUI>().text = "���������";
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

    void Start()
    {
        
    }

    void Update()
    {
        if(playerInColliderFlag && Input.GetKeyDown(KeyCode.E))
        {
            if(!DialogueLua.GetVariable("PhotoFragment").asBool && DialogueLua.GetVariable("FirstDerylConversation").asBool)
            {
                if (inventory.FindItemByNameAndQuantity("������", 4))
                {
                    inventory.RemoveItem(coin, 4);
                    inventory.AddItem(item);          
                    DialogueManager.ShowAlert("������� �������", 1f);
                    DialogueLua.SetVariable("PhotoFragment", true);
                }
                else
                {
                    DialogueManager.Bark("FoodMachine2", GameObject.FindGameObjectWithTag("Player").transform);
                }
            }
            else
            {
                DialogueManager.Bark("FoodMachine1", GameObject.FindGameObjectWithTag("Player").transform);
            }
            
        }
    }


}

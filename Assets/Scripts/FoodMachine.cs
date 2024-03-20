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

    void Start()
    {
        
    }

    void Update()
    {
        if(playerInColliderFlag && Input.GetKeyDown(KeyCode.E))
        {
            if(!DialogueLua.GetVariable("PhotoFragment").asBool && DialogueLua.GetVariable("FirstDerylConversation").asBool)
            {
                if (inventory.FindItemByNameAndQuantity("Монета", 3))
                {
                    inventory.RemoveItem(coin, 3);
                    inventory.AddItem(item);          
                    DialogueManager.ShowAlert("Получен предмет", 1f);
                    DialogueLua.SetVariable("PhotoFragment", true);
                }
                else
                {
                    DialogueManager.ShowAlert("Недостаточно монет", 1f);
                }
            }
            else
            {

            }
            
        }
    }


}

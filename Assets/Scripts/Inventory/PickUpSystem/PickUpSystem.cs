using Inventory2.Model;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private InventorySO inventoryData;

    public GameObject panel;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Item item = collider.GetComponent<Item>();
        if (item != null)
        {
            panel.SetActive(true);
            panel.GetComponentInChildren<TMP_Text>().text = item.InventoryItem.Name;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 1f);
        Item item = collider.GetComponent<Item>();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (item != null)
            {
                int reminder = inventoryData.AddItem(item.InventoryItem, item.Quantity);
                if (reminder == 0)
                    item.DestroyItem();
                else
                    item.Quantity = reminder;
            }
        }
    }
}

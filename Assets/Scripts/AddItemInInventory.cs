using Inventory2.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemInInventory : MonoBehaviour
{
    public InventoryItem item;
    public InventorySO inventory;

    public void AddItem()
    {
        inventory.AddItem(item);
    }
}

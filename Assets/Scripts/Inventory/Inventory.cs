using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> items = new List<InventorySlot>();
    public event Action OnInventoryChanged;

    public void AddItem(ItemData itemData)
    {
        // cerca se già esiste
        InventorySlot slot = items.Find(i => i.item == itemData);

        if (slot != null && itemData.stackable)
        {
            slot.quantity++;
        }
        else
        {
            InventorySlot newSlot = new InventorySlot();
            newSlot.item = itemData;
            newSlot.quantity = 1;

            items.Add(newSlot);
        }

        OnInventoryChanged?.Invoke();
        DebugInventory();
    }

    void DebugInventory()
    {
        Debug.Log("Inventario:");

        foreach (var slot in items)
        {
            if (slot.item != null)
                Debug.Log(slot.item.itemName + " x" + slot.quantity);
            else
                Debug.Log("Item NULL!");
        }
    }
}

// classe helper

[System.Serializable]
public class InventorySlot
{
    public ItemData item;
    public int quantity;
}
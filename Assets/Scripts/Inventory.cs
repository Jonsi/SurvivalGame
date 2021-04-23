using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<InventorySlot> ItemSlots;
    public int MaxSlots;

    public bool isFull { get { return ItemSlots.Count == MaxSlots; } }

    /// <summary>
    /// Rerturns the slot of the added item, null if failed to add.
    /// </summary>
    public InventorySlot AddItemToSlot(Item item)
    {
        foreach(InventorySlot slot in ItemSlots)
        {
            if(slot.ItemObject.ItemType == item.ItemType)
            {
                if(slot.Amount < item.MaxAmount)
                {
                    slot.Amount++;
                    return slot;
                }
            }
        }

        if (isFull)
        {
            Debug.LogError("TRYING TO ADD ITEM TO FULL INV");
            return null;
        }

        InventorySlot newSlot = new InventorySlot(item);
        ItemSlots.Add(newSlot);
        newSlot.index = ItemSlots.IndexOf(newSlot);
        return ItemSlots[ItemSlots.IndexOf(newSlot)];
    }
}

[System.Serializable]
public class InventorySlot
{
    public Item ItemObject;
    public int Amount;
    public int index = -1;
    public InventorySlot(Item item)
    {
        Amount = 1;
    }
}

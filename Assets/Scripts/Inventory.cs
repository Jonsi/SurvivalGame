using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> Slots;
    public int MaxSlots;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToSlot(CollectableItem item)
    {
        if(Slots.Count == MaxSlots)
        {
            Debug.Log("Inv' full. REMOVE AND ADD MESSAGE");
            return;
        }

        foreach(InventorySlot slot in Slots)
        {
            if(slot.ItemType == item.ItemType)
            {
                //already hve item
                slot.Amount++;
                return;
            }
        }

        Slots.Add(new InventorySlot(item));

    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemType ItemType;
    public int Amount;

    public InventorySlot(CollectableItem item)
    {
        ItemType = item.ItemType;
        Amount = 1;
    }
}

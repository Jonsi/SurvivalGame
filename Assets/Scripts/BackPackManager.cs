using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackManager : MonoBehaviour
{
    public Inventory Inventory;
    public Transform ItemsHolder;

    // Start is called before the first frame update
    void Start()
    {
        //Inventory = new Inventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Returns added item, null if failed to add
    /// </summary>
    public Item AddItemToBackPack(Item item)
    {
        InventorySlot slot = Inventory.AddItemToSlot(item);

        if(slot!= null)
        {
            if (slot.Amount == 1)
            {
                slot.ItemObject = InitItemObject(item.ItemPrefab);
            }

            return slot.ItemObject;
        }
        else
        {
            return null;
        }
    }

    public void InitHolderItems()
    {
        foreach (InventorySlot slot in Inventory.ItemSlots)
        {
            Instantiate(slot.ItemObject.ItemPrefab, ItemsHolder);
        }
    }

    public Item InitItemObject(Item prefab)
    {
        Item itemGameobject = Instantiate(prefab, ItemsHolder);
        itemGameobject.gameObject.SetActive(false);
        itemGameobject.transform.localPosition = Vector3.zero;
        itemGameobject.transform.localRotation = Quaternion.Euler(Vector3.zero);
        itemGameobject.GetComponent<Rigidbody>().isKinematic = true;
        itemGameobject.GetComponent<BoxCollider>().enabled = false;

        return itemGameobject;
    }
}

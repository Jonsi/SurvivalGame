using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour
{
    public Inventory Inventory;
    public Transform ItemsHolder;

    public int InventroySize = 1;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.MaxSlots = InventroySize;
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
                EventManager.Singleton.OnItemSetToSlot(slot);
            }
            else
            {
                EventManager.Singleton.OnExistingItemCollected(slot);
            }

            return slot.ItemObject;
        }
        else
        {
            return null;
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

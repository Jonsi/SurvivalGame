using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiBackpack : UiWindow
{
    public List<UiInventorySlot> UiSlotList;
    public UiInventorySlot UiSlotPrefab;
    public Transform SlotsParent;
    
    public int Size = 6;//SET SIZE FROM BACKPACK
    public float Radius = 1;

    private void Awake()
    {
        Size = PlayerController.Singleton.PlayerBackpack.InventroySize;
    }

    private void OnEnable()
    {
        EventManager.Singleton.E_ItemSetToSlot += SetNewUiSlot;
        EventManager.Singleton.E_ExistingItemCollected += SetUiSlotAmont;
    }

    private void OnDestroy()
    {
        EventManager.Singleton.E_ItemSetToSlot += SetNewUiSlot;
        EventManager.Singleton.E_ExistingItemCollected += SetUiSlotAmont;
    }
    // Start is called before the first frame update
    void Start()
    {
        InitSlots();

        foreach(InventorySlot slot in PlayerController.Singleton.PlayerBackpack.Inventory.ItemSlots)
        {
            SetNewUiSlot(slot);
        }
    }

    public void InitSlots()
    {
        //SET SIZE ON BACKPACK INIT
        for (int i = 0; i < Size; i++)
        {
            float angle = (Mathf.PI * 2* i) / Size;
            Vector2 slotPos = new Vector2(Radius * Mathf.Cos(angle), Radius * Mathf.Sin(angle));
            UiInventorySlot slot = Instantiate(UiSlotPrefab,SlotsParent);
            slot.gameObject.transform.localPosition = slotPos;
            UiSlotList.Add(slot);
        }
    }

    public void SetNewUiSlot(InventorySlot slot)
    {
        UiSlotList[slot.index].SetUiSlot(slot);
    }

    public void SetUiSlotAmont(InventorySlot slot)
    {
        UiSlotList[slot.index].SetAmount(slot.Amount);
    }

    public void EquipItem()
    {
        //activate UiSlots
        //getmouse pos 
    }
}



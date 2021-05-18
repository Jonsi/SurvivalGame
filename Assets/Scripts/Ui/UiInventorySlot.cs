using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiInventorySlot : InteractableUi
{
    public bool IsEmpty { get { return Slot.Amount == 0; } }
    public InventorySlot Slot;
    public TextMeshProUGUI TextAmount;
    public Image itemImage;

    public Color SelectColor;

    public void SetUiSlot(InventorySlot slot)
    {
        Slot = slot;
        itemImage.sprite = slot.ItemObject.ItemSprite;
        SetAmount(slot.Amount);
    }

    public void SetAmount(int amount)
    {
        TextAmount.text = Slot.Amount.ToString();
    }

    public void SelectSlot()
    {
        //start fade animation
        itemImage.color = SelectColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit by: " + collision.gameObject.name);
    }

    public void UnSelectSlot()
    {
        itemImage.color = Color.white;
    }

    public override void OnHover()
    {
        
    }

    public override void OnUiClick()
    {
        EventManager.Singleton.OnUiItemEquiped(Slot.ItemObject);
    }
}

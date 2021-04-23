using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{ 
    public static EventManager Singleton;

    private void Awake()
    {
        Singleton = this;
    }

    public delegate void Interaction(InteractionType type);
    public static event Interaction OnInteractionStarted;

    public delegate void D_OnChopableDestroyed(ChopableObject chopObj);
    public event D_OnChopableDestroyed E_ChopableDestroyed;

    public delegate void D_OnExistingItemCollected(InventorySlot slot);
    public event D_OnExistingItemCollected E_ExistingItemCollected;

    public delegate void D_OnItemSetToSlot(InventorySlot slot);
    public event D_OnItemSetToSlot E_ItemSetToSlot;

    public delegate void D_OnUiWindowActivated(UiWindowType type);
    public event D_OnUiWindowActivated E_UiWindowActivated;

    public delegate void D_OnUiWindowDisabled(UiWindowType type);
    public event D_OnUiWindowDisabled E_UiWindowDisabled;

    public delegate void D_OnUiItemEquiped(Item item);
    public event D_OnUiItemEquiped E_UiItemEquiped;


    public void StartInteraction(InteractableObject target, InteractionType type)
    {
        OnInteractionStarted?.Invoke(type);
    }

    public void OnChopableDestroyed(ChopableObject chopObj)
    {
        E_ChopableDestroyed?.Invoke(chopObj);
    }

    public void OnExistingItemCollected(InventorySlot slot)
    {
        E_ExistingItemCollected?.Invoke(slot);
    }

    public void OnItemSetToSlot(InventorySlot slot)
    {
        E_ItemSetToSlot?.Invoke(slot);
    }

    public void OnUiWindowActivated(UiWindowType type)
    {
        E_UiWindowActivated?.Invoke(type);
    }
    public void OnUiWindowDisabled(UiWindowType type)
    {
        E_UiWindowDisabled?.Invoke(type);
    }

    public void OnUiItemEquiped(Item item)
    {
        E_UiItemEquiped?.Invoke(item);
    }

}

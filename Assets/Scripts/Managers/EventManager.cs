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

    public delegate void D_OnItemCollected(Item collObj);
    public event D_OnItemCollected E_ItemCollected;

    public void StartInteraction(InteractableObject target, InteractionType type)
    {
        OnInteractionStarted?.Invoke(type);
    }

    public void OnChopableDestroyed(ChopableObject chopObj)
    {
        E_ChopableDestroyed?.Invoke(chopObj);
    }

    public void OnItemCollected(Item collObj)
    {
        E_ItemCollected?.Invoke(collObj);
    }

}

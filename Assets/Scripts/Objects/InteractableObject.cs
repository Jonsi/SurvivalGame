using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InteractionType
{
    PICKUP,
    HIT,
    USE,
}

public class InteractableObject : MonoBehaviour,IInteractable
{
    public virtual void Interact(InteractionType type)
    {
        //ACTION FOR ALL TYPES
    }

    public virtual void Interact(InteractionType type,UnitStats stats)
    {
        //ACTION FOR ALL TYPES
    }

    public void OnHover()
    {
        throw new System.NotImplementedException();
    }

    public void OnHoverOff()
    {
        throw new System.NotImplementedException();
    }
    
}

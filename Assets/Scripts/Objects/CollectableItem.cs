﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    WOOD
}

public class CollectableItem : InteractableObject
{
    public ItemType ItemType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact(InteractionType type)
    {
        if(type == InteractionType.PICKUP)
        {
            EventManager.Singleton.OnItemCollected(this);
            Destroy(gameObject);
        }
    }
}

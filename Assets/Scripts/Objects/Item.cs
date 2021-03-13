using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    WOOD,
    TOOL
}

public class Item : InteractableObject
{
    public Item ItemPrefab;
    public int MaxAmount;
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
            Destroy(gameObject);
        }
    }
}

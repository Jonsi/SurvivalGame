﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChopableType
{
    TREE
}

public class ChopableObject : InteractableObject, IDamageable
{
    public ChopableType ChopableType;
    public CollectableItem CollectableItemPrefab;
    public int health = 1; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetHit(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            EventManager.Singleton.OnChopableDestroyed(this);
            for (int i = 0; i < CollectableItemPrefab.Amount; i++)
            {
                Instantiate(CollectableItemPrefab,transform.position,Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    public override void Interact(InteractionType type, UnitStats stats)
    {
        if(type == InteractionType.HIT)
        {
            GetHit(stats.Damage);
        }
    }
}
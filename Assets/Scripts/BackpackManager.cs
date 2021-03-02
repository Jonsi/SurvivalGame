using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackManager : MonoBehaviour
{
    public static BackpackManager Singleton;
    public Inventory Inventory;

    private void Awake()
    {
        Singleton = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        EventManager.Singleton.E_ItemCollected += AddItemToBackpack;
    }

    private void OnDisable()
    {
        EventManager.Singleton.E_ItemCollected -= AddItemToBackpack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToBackpack(CollectableItem item)
    {
        Inventory.AddItemToList(item);
    }
}

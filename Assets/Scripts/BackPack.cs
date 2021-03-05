using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour
{
    public Inventory Inventory;
    

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToBackpack(CollectableItem item)
    {
        Inventory.AddItemToSlot(item);
    }
}

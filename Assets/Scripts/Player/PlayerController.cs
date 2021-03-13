using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAnim
{
    public static string HIT { get { return "Hit"; } }
}

public class PlayerController : MonoBehaviour
{
    public PlayerStats PlayerStats;
    public BackPackManager Backpack;
    public Item EquipedItem;
    public InteractableObject _target;
    public Animator Animtor;
    
    // Start is called before the first frame update
    void Start()
    {
        _target = null;
    }
    private void OnEnable()
    {
        //EventManager.Singleton.E_ItemCollected += CollectItem;
    }

    private void OnDisable()
    {
        //EventManager.Singleton.E_ItemCollected -= CollectItem;
    }


    // Update is called once per frame
    void Update()
    {
        SetTarget();
        GetInput();
    }

    public void SetTarget()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _target = hit.transform.GetComponent<InteractableObject>();
        }
        else
        {
            _target = null;
        }
    }
    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Animtor.SetTrigger(PlayerAnim.HIT);
        }

        if (_target != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                HandlePickup();
            }
        }
    }
    private void HandleHit()
    {
        if(_target!= null)
        {
            _target.Interact(InteractionType.HIT);
        }
    }
    private void HandlePickup()
    {
        Item item = _target.GetComponent<Item>();

        if(item != null)
        {
            Item addedItem = Backpack.AddItemToBackPack(item);

            if(addedItem != null)
            {
                _target.Interact(InteractionType.PICKUP);

                if (EquipedItem == null)
                {
                    EquipItem(addedItem);
                }
            }
        }
    }

    public void EquipItem(Item item)
    {
        if(EquipedItem != null)
        {
            EquipedItem.gameObject.SetActive(false);
        }

        EquipedItem = item;
        EquipedItem.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStats playerStats;
    public BackpackManager Backpack;
    public InteractableObject _target;
    
    // Start is called before the first frame update
    void Start()
    {
        _target = null;
        Backpack = BackpackManager.Singleton;
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

    public void HandleInteraction(InteractionType type){
        
        if(_target != null)
        {

        }
    }

    public void GetInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _target.Interact(InteractionType.HIT, playerStats);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _target.Interact(InteractionType.PICKUP);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerStats playerStats;
    public BackPack Backpack;
    public InteractableObject _target;
    public Animator Animtor;
    
    // Start is called before the first frame update
    void Start()
    {
        _target = null;
    }
    private void OnEnable()
    {
        EventManager.Singleton.E_ItemCollected += CollectItem;
    }

    private void OnDisable()
    {
        EventManager.Singleton.E_ItemCollected -= CollectItem;
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
            Hit();
        }

        if (_target != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _target.Interact(InteractionType.PICKUP);
            }
        }
    }

    private void CollectItem(CollectableItem item)
    {
        Backpack.AddItemToBackpack(item);
    }

    private void Hit()
    {
        Animtor.SetTrigger(PlayerAnim.HIT);
    }

    private class PlayerAnim
    {
        public static string HIT { get { return "Hit"; } }
        public static string HIT1 { get { return "HIT"; } }
        public static string HIT2 { get { return "HIT"; } }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiSlotSelector : MonoBehaviour
{
    public UiInventorySlot SelectedSlot;
    public float MouseSensitivity = 10;//SET FROM PLAYER
    public float Radius=200;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDisable()
    {
        if (SelectedSlot)
        {
            EventManager.Singleton.OnUiItemEquiped(SelectedSlot.Slot.ItemObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UiInventorySlot uiSlot = collision.gameObject.GetComponent<UiInventorySlot>();
        if (!uiSlot.IsEmpty)
        {
            if (SelectedSlot)
            {
                SelectedSlot.UnSelectSlot();
            }

            SelectedSlot = uiSlot;
            uiSlot.SelectSlot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Center = Vector2.zero;
        Vector2 mousePosition = Input.mousePosition;

        mousePosition.x -= Screen.width / 2;
        mousePosition.y -= Screen.height / 2;

        Vector2 direction = mousePosition - Center; //direction from Center to Cursor
        Vector2 normalizedDirection = direction.normalized;
 
        transform.localPosition = Center + (normalizedDirection * Radius);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void OnHover();
    void OnHoverOff();
    void Interact(InteractionType type);
}

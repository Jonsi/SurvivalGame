using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable : IInteractable
{
    void GetHit(int damage);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    AXE
}

public class Weapon : Tool
{
    public WeaponType WeaponType;
    public int Damage = 1;
    public Transform HitBox;

    private void OnTriggerEnter(Collider other)
    {
        
    }
}

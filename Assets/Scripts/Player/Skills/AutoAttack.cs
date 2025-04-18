using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : BaseSkill
{
    private void Awake()
    {
        DamageType = Player.Instance.Inventory.Weapon == null? 
            DamageType.Bludgeoning :
            Player.Instance.Inventory.Weapon.DamageType;
    }

    public void ChangeDamageType() {
        DamageType = Player.Instance.Inventory.Weapon.DamageType;
    }
}

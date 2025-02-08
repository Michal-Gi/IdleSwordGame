using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public Gear Weapon;
    [SerializeField]
    public Gear Armor;
    [SerializeField]
    public Gear Ring;
    [SerializeField]
    public Gear Necklace;
    [SerializeField]
    public Gear Helmet;
    [SerializeField]
    public Gear Pants;
    [SerializeField]
    public Gear Gloves;
    [SerializeField]
    public Gear Boots;
    [SerializeField]
    public Gear Cape;

    public UnityEvent OnEquipmentChanged;

    public void ChangeEquipment(Gear equipment)
    {
        Debug.Log("inventory changed");
        switch (equipment.GearType)
        {
            case GearType.Weapon: Weapon = equipment; break;
            case GearType.Armor: Armor = equipment; break;
            case GearType.Ring: Ring = equipment; break;
            case GearType.Necklace: Necklace = equipment; break;
            case GearType.Helmet: Helmet = equipment; break;
            case GearType.Pants: Pants = equipment; break;
            case GearType.Gloves: Gloves = equipment; break;
            case GearType.Cape: Cape = equipment; break;
            case GearType.Boots: Boots = equipment; break;
            default: break;
        };
        OnEquipmentChanged?.Invoke();
    }
}

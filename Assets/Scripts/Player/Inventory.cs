using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public GearData Weapon;
    [SerializeField]
    public GearData Armor;
    [SerializeField]
    public GearData Ring;
    [SerializeField]
    public GearData Necklace;
    [SerializeField]
    public GearData Helmet;
    [SerializeField]
    public GearData Pants;
    [SerializeField]
    public GearData Gloves;
    [SerializeField]
    public GearData Boots;
    [SerializeField]
    public GearData Cape;

    public UnityEvent OnEquipmentChanged;
    public UnityEvent OnWeaponChanged;

    public void ChangeEquipment(GearData equipment)
    {
#if UNITY_EDITOR
        Debug.Log("inventory changed");
#endif
        switch (equipment.GearType)
        {
            case GearType.Weapon: { Weapon = equipment; OnWeaponChanged?.Invoke(); break; }
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

    public void PickItem(GameObject item) {
        if (item == null) return;
        if (item.gameObject.GetComponent<Gear>() != null)
        {
            ChangeEquipment(item.GetComponent<Gear>().GearData);
            item.gameObject.GetComponent<Gear>().DestroyOnClicked();
            return;
        }
        //TODO: Add loot logic
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public static BaseEnemy CurrentEnemy { get; set; }

    [SerializeField]
    public int BaseDamage;

    [SerializeField]
    public float BaseAccuracy;

    [SerializeField]
    public float BaseAttackRate;

    [SerializeField]
    public Inventory Inventory;

    public float currentDamage;

    public float currentAccuracy => BaseAccuracy;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        currentDamage = BaseDamage;
        DontDestroyOnLoad(gameObject);
    }

    public void Attack(BaseEnemy enemy)
    {
        enemy._healthSystem.TakeDamage(currentDamage);
    }

    public static void SetEnemy(BaseEnemy enemy)
    {
        CurrentEnemy = enemy;
    }

    public void UpdateCurrentDamage()
    {
#if UNITY_EDITOR
        Debug.Log("Damage updated");
#endif
        currentDamage = BaseDamage;
        currentDamage += Inventory.Weapon == null ? 0 : Inventory.Weapon.Damage;
        currentDamage += Inventory.Armor == null ? 0 : Inventory.Armor.Damage;
        currentDamage += Inventory.Ring == null ? 0 : Inventory.Ring.Damage;
        currentDamage += Inventory.Necklace == null ? 0 : Inventory.Necklace.Damage;
        currentDamage += Inventory.Helmet == null ? 0 : Inventory.Helmet.Damage;
        currentDamage += Inventory.Pants == null ? 0 : Inventory.Pants.Damage;
        currentDamage += Inventory.Gloves == null ? 0 : Inventory.Gloves.Damage;
        currentDamage += Inventory.Boots == null ? 0 : Inventory.Boots.Damage;
        currentDamage += Inventory.Cape == null ? 0 : Inventory.Cape.Damage;
    }
}

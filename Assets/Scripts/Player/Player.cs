using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

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

    public int level;

    public int expToNextLevel;

    public int currentEXP;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        currentDamage = BaseDamage;
        DontDestroyOnLoad(gameObject);
        level = 1;
        expToNextLevel = 10;
        currentEXP = 0;
    }

    public void ReceiveEXP(int amount)
    {
        currentEXP += amount;
        if (currentEXP < expToNextLevel) { return; }
        level++;
#if UNITY_EDITOR
        Debug.Log($"level up! your level is {level}");
#endif
        currentEXP = expToNextLevel - currentEXP;
        if (level < 5)
        {
            expToNextLevel *= 2;
            return;
        }

        expToNextLevel = (int)Math.Round(expToNextLevel * 1.1f);
    }

    public void Attack(BaseEnemy enemy)
    {
        enemy._healthSystem.TakeDamage(currentDamage);
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

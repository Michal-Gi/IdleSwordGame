using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    public HealthSystem _healthSystem;

    [SerializeField]
    public int Armor;

    [SerializeField]
    public int EXP;

    [SerializeField]
    public ResistanceDict ResistanceDict;

    private Dictionary<DamageType, float> DamageResistancyMultiplayers;

    private void Awake()
    {
        DamageResistancyMultiplayers = ResistanceDict.ToDict();
    }

    public void GetAttacked(float damage, DamageType damageType) {
        if(damage < Armor) { damage = Armor; }
        if (!DamageResistancyMultiplayers.TryGetValue(damageType, out float damageReduction)) {
            Debug.Log("damage type not found in the list");
            damageReduction = 0;
        }
        else
        {
            Debug.Log("Damage type found");
            damageReduction = DamageResistancyMultiplayers[damageType];
        }
        _healthSystem.TakeDamage(damage * (1 - damageReduction) - Armor);
    }
}

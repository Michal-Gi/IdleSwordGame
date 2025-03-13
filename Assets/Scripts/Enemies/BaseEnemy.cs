using System;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    #region general
    [SerializeField]
    public HealthSystem _healthSystem;

    [SerializeField]
    public int Armor;

    [SerializeField]
    public int EXP;

    #endregion
    [Header("Resistances")]
    #region Damage Type Resistance
    [SerializeField]
    public float BludgeoningResistance = 0;
    [SerializeField]
    public float PiercingResistance = 0;
    [SerializeField]
    public float SlashingResistance = 0;
    [SerializeField]
    public float FireResistance = 0;
    [SerializeField]
    public float ColdResistance = 0;
    [SerializeField]
    public float NecroticResistance = 0;
    [SerializeField]
    public float LightningResistance = 0;
    [SerializeField]
    public float PsychicResistance = 0;
    [SerializeField]
    public float PoisonResistance = 0;
    [SerializeField]
    public float AcidResistance = 0;
    [SerializeField]
    public float ThunderResistance = 0;
    [SerializeField]
    public float ForceResistance = 0;
    [SerializeField]
    public float TrueResistance = 0;
    [SerializeField]
    public float RadiantResistance = 0;

    #endregion

    public float GetEnemyResistance(DamageType damageType) {
        switch (damageType)
        {
            case DamageType.Bludgeoning: return BludgeoningResistance;
            case DamageType.Piercing: return PiercingResistance;
            case DamageType.Slashing: return SlashingResistance;
            case DamageType.Fire: return FireResistance;
            case DamageType.Cold: return ColdResistance;
            case DamageType.Necrotic: return NecroticResistance;
            case DamageType.Lightning: return LightningResistance;
            case DamageType.Psychic: return PsychicResistance;
            case DamageType.Poison: return PoisonResistance;
            case DamageType.Acid: return AcidResistance;
            case DamageType.Thunder: return ThunderResistance;
            case DamageType.Force: return ForceResistance;
            case DamageType.True: return TrueResistance;
            case DamageType.Radiant: return RadiantResistance;
            default: return 0;
        }
    }

    public void GetAttacked(float damage, DamageType damageType) {
        _healthSystem.TakeDamage(Math.Max(damage * (1 - GetEnemyResistance(damageType)) - Armor, 0));
    }
}

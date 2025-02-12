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
    public int Defense;

    [SerializeField]
    public int Armor;

    [SerializeField]
    public int EXP;

    public void GetAttacked(float damage) {
        if(damage < Armor) { damage = Armor; }
        _healthSystem.TakeDamage(damage - Armor);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public int BaseDamage;

    [SerializeField]
    public float BaseAccuracy;

    [SerializeField]
    public float BaseAttackRate;

    [SerializeField]
    public HealthSystem CurrentEnemy;

    public void Awake()
    {

    }

    public float currentDamage => BaseDamage;
}

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

    public float currentDamage => BaseDamage;

    public void Update()
    {
        if (InputHandler.Instance.Attack)
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (CurrentEnemy != null)
        {
            CurrentEnemy.TakeDamage(currentDamage);
        }
    }
}

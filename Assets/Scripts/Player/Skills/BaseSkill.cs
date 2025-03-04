using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill : MonoBehaviour
{
    [SerializeField]
    public float Damage;

    [SerializeField]
    public DamageType DamageType;

    [SerializeField]
    public float CoolDown;

    private float TimeLeft;

    public void Upgrade(int timesToUpgrade)
    {
        if (Player.Instance.SkillPoints < timesToUpgrade) { return; }
        for (int i = 0; i < timesToUpgrade; i++)
        {
            CoolDown -= Math.Max(1, CoolDown - 0.1f);
            Damage += Math.Max(1, Damage * 1.1f);
        }
    }

    private void Awake()
    {
        TimeLeft = 0;
    }

    private void FixedUpdate()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft > 0) { return; }
        AttackEnemy();
    }

    public void AttackEnemy()
    {
        EnemyManager.Instance.CurrentEnemyInstance.GetComponent<BaseEnemy>().GetAttacked(Damage, DamageType);
        TimeLeft = CoolDown;
    }

}

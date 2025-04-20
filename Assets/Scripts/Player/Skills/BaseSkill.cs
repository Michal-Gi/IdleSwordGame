using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BaseSkill : MonoBehaviour
{
    [SerializeField]
    public float Damage;

    public DamageType DamageType {  get; protected set; }

    [SerializeField]
    public float CoolDown;

    [SerializeField]
    public int Level;

    [SerializeField]
    public TextMeshProUGUI SkillDamageValuesDisplay;

    [SerializeField]
    public TextMeshProUGUI SkillLevelDisplay;

    public UnityEvent<int> OnSkillLevelUp;

    public UnityEvent<string> OnSkillLevelUpTextUIChange;

    private float TimeLeft;

    public void Upgrade(int timesToUpgrade)
    {
        if (Player.Instance.SkillPoints < timesToUpgrade) { return; }
        for (int i = 0; i < timesToUpgrade; i++)
        {
            CoolDown = Math.Max(1, CoolDown - 0.1f);
            Damage += Math.Max(1, Damage * 1.1f);
            Level++;
            Player.Instance.SkillPoints--;
            OnSkillLevelUp.Invoke(Level);
            //OnSkillLevelUpTextUIChange.Invoke(GetDamageForUI());
            SkillDamageValuesDisplay.text = GetDamageForUI();
            SkillLevelDisplay.text = $"Lv. {Level}";
        }
    }

    public string GetDamageForUI() {
        return $"{Damage} -> {Math.Max(1, Damage * 1.1f)}";
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

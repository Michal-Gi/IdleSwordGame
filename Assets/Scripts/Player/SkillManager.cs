using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public int CurrentSkillUpgradeAmount { get; set; }

    private void Awake()
    {
        CurrentSkillUpgradeAmount = 1;
    }

    public void SetCurrentSkillUpgradeAmount(int amount)
    {
        CurrentSkillUpgradeAmount = amount;
    }

}

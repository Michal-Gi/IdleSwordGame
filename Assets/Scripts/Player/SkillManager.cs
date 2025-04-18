using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }

    public int CurrentSkillUpgradeAmount { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
        CurrentSkillUpgradeAmount = 1;
    }

    public void SetCurrentSkillUpgradeAmount(int amount)
    {
        CurrentSkillUpgradeAmount = amount;
    }

}

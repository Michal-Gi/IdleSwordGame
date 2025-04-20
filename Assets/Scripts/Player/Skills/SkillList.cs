using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillList : MonoBehaviour
{
    [SerializeField]
    public List<UpgradeSkillButtonUI> UpgradeButtons;

    public void UpdateButtonStates() {
        Player.Instance.UpdateSkillPointsAmountUI();
        if (Player.Instance.SkillPoints >= SkillManager.Instance.CurrentSkillUpgradeAmount)
        {
            foreach (var button in UpgradeButtons)
            {
                button.WakeUp();
            }
        }
        else {
            foreach (var button in UpgradeButtons)
            {
                button.PutToSleep();
            }
        }
    }
}

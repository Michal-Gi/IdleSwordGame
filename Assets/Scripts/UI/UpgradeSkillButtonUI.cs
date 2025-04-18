using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSkillButtonUI : MonoBehaviour
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();

        button.image.color = button.colors.disabledColor;
        button.enabled = false;
    }

    public void WakeUp()
    {
        if (Player.Instance.SkillPoints < SkillManager.Instance.CurrentSkillUpgradeAmount) { return; }
        button.enabled = true;
        button.image.color = button.colors.normalColor;
    }

    public void PutToSleep()
    {
        if (Player.Instance.SkillPoints >= SkillManager.Instance.CurrentSkillUpgradeAmount) { return; }
        button.image.color = button.colors.disabledColor;
        button.enabled = false;
    }
}

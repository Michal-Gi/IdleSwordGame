using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentSkillDamageValueDisplay : MonoBehaviour
{
    private TextMeshProUGUI DamageDisplay;
    public void Awake()
    {
        DamageDisplay = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateDisplayedDamage(string DamageText) {
        DamageDisplay.text = DamageText;
    }
}

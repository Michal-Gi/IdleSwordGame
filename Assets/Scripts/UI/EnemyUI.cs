using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField]
    public Slider Slider;

    [SerializeField]
    public TextMeshProUGUI EnemyNameField;

    [SerializeField]
    public string EnemyName;

    private void Start()
    {
        Slider.value = 1;
        EnemyNameField.text = EnemyName;
        EnemyManager.Instance.CurrentEnemyInstance.GetComponent<HealthSystem>().OnDamageReceived.AddListener(UpdateHPBar);
    }

    public void UpdateHPBar() {
        var currentHP = EnemyManager.Instance.CurrentEnemyInstance.GetComponent<HealthSystem>()._currentHealth;
        var maxHP = EnemyManager.Instance.CurrentEnemyInstance.GetComponent<HealthSystem>().Health;
        Slider.value = currentHP / maxHP;

    }

    private void OnDestroy()
    {
        EnemyManager.Instance.CurrentEnemyInstance.GetComponent<HealthSystem>().OnDamageReceived.RemoveListener(UpdateHPBar);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUpgradeAmountButtonLogic : MonoBehaviour
{
    private Button button;

    [SerializeField]
    public int amount;

    private void Awake()
    {
        button = GetComponent<Button>();

        button.image.color = button.colors.disabledColor;
        button.enabled = false;
    }


    public void WakeUp()
    {
        if (Player.Instance.SkillPoints < amount) { return; }
        button.enabled = true;
        button.image.color = button.colors.normalColor;
    }

    public void PutToSleep()
    {
        if (Player.Instance.SkillPoints >= amount) { return; }
        button.image.color = button.colors.disabledColor;
        button.enabled = false;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIChangeGear : MonoBehaviour
{
    [SerializeField]
    public GearData Gear;
    
    public UnityEvent<GearData> OnGearChange;

    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ChangeGear);
    }

    private void ChangeGear()
    {
            OnGearChange.Invoke(Gear);
    }
}

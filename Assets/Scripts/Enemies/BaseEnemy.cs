using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    public HealthSystem _healthSystem;

    [SerializeField]
    public int Defense;

    public void Awake()
    {
        Player.SetEnemy(this);
    }
}

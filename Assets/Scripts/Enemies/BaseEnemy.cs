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


    private BoxCollider2D _hitbox;

    public void Awake()
    {
        _hitbox = GetComponent<BoxCollider2D>();        
    }

    private void Update()
    {
        if (InputHandler.Instance.MouseClicked)
        {

        }
    }
}

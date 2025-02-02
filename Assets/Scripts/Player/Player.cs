using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public static BaseEnemy CurrentEnemy { get; set; }

    [SerializeField]
    public int BaseDamage;

    [SerializeField]
    public float BaseAccuracy;

    [SerializeField]
    public float BaseAttackRate;


    public float currentDamage => BaseDamage;
    
    public float currentAccuracy => BaseAccuracy;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        if (InputHandler.Instance.Attack)
        {
            Attack();
        }
    }

    public void Attack()
    {
        CurrentEnemy._healthSystem.TakeDamage(currentDamage);
    }

    public static void SetEnemy(BaseEnemy enemy)
    {
        if (Instance != null)
        {
            CurrentEnemy = enemy;
        }
    }
}

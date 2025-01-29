using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    public float Health;

    [SerializeField]
    public List<Drop> drops;

    [SerializeField]
    public UnityEvent OnDeath;

    private float _currentHealth;

    public void Awake()
    {
        _currentHealth = Health;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log($"current health is: {_currentHealth}");
        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die() { 
        OnDeath.Invoke();
        Destroy(gameObject);
    }
}

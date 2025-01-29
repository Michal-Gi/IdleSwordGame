using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    public float Health;

    [SerializeField]
    public List<Drop> drops;

    private float _currentHealth;

    public void Awake()
    {
        _currentHealth = Health;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if(_currentHealth < 0)
        {

        }
    }

    public void Die() { 
        Destroy(gameObject);
    }
}

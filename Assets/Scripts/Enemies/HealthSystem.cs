using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    public float Health;

    [SerializeField]
    public List<GameObject> drops;

    [SerializeField]
    public UnityEvent OnDeath;

    [SerializeField]
    public float DeathAnimationDelay;


    private float _currentHealth;

    public void Awake()
    {
        _currentHealth = Health;
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth <= 0) { return; }
        _currentHealth -= damage;
#if UNITY_EDITOR
        Debug.Log($"current health is: {_currentHealth}");
#endif
        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die() { 
        OnDeath.Invoke();
        if (GetComponent<BossEnemy>())
        {
            EnemyManager.Instance.SetNextBoss();
        }
        Player.Instance.ReceiveEXP(GetComponent<BaseEnemy>().EXP);
        GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(DelayRespawn());
        foreach(var drop in drops)
        {
            Instantiate(drop, new Vector3(transform.position.x + 2, transform.position.y + 2, transform.position.z), Quaternion.Euler(0,0,0));
        }
    }

    IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(DeathAnimationDelay);
        Destroy(gameObject);
        EnemyManager.Instance.SpawnEnemy();
    }
}

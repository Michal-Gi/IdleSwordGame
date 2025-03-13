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
    public UnityEvent OnDamageReceived;

    [SerializeField]
    public float DeathAnimationDelay;


    public float _currentHealth;

    public void Awake()
    {
        _currentHealth = Health;
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth <= 0) { return; }
        _currentHealth -= damage;
        OnDamageReceived.Invoke();
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
            var dropItem = Instantiate(drop, transform.position, Quaternion.Euler(0,0,0));
            dropItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1.25f, 1.25f)*100, 250));
        }
    }

    IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(DeathAnimationDelay);
        Destroy(gameObject);
        EnemyManager.Instance.SpawnEnemy();
    }
}

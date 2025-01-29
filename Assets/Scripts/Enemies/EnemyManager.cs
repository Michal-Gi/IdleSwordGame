using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> MobsToSpawn;

    [SerializeField]
    public List<GameObject> BossesToSpawn;

    private int _currentMobIndex;

    private GameObject _currentEnemy;

    public void Awake()
    {
        _currentMobIndex = 0;
        _currentEnemy = MobsToSpawn.ElementAt(_currentMobIndex);
    }

    public void SpawnEnemy()
    {
        Instantiate(_currentEnemy, gameObject.transform.position, Quaternion.Euler(0,0,0));
    }

    public void StartBossFight()
    {
        
    }

    
}

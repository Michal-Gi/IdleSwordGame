using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    [SerializeField]
    public List<GameObject> MobsToSpawn;

    [SerializeField]
    public List<GameObject> BossesToSpawn;

    [SerializeField]
    private Player Player;

    private int _currentMobIndex;

    private GameObject _currentEnemy;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(Instance);
        _currentMobIndex = 0;
        _currentEnemy = MobsToSpawn[_currentMobIndex];
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        Instantiate(_currentEnemy, gameObject.transform.position, Quaternion.Euler(0,0,0));
    }

    public void SetNextEnemy() {
        if (_currentMobIndex >= MobsToSpawn.Count-1) { return; }
        _currentMobIndex++;
        _currentEnemy = MobsToSpawn[ _currentMobIndex ];
    }

    public void SetPreviousEnemy()
    {
        if (_currentMobIndex <= 0) { return; }
        _currentMobIndex--;
        _currentEnemy = MobsToSpawn[_currentMobIndex];
    }

    public void StartBossFight()
    {
        //TODO - add button to despawn enemy and spawn a boss
    }

    
}

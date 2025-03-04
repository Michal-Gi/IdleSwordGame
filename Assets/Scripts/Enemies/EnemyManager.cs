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

    [SerializeField]
    public float EnemySwapAnimationDelay;

    private int _currentMobIndex;

    private int _currentBossIndex;

    private GameObject _currentEnemyPrefab;

    private GameObject _currentBossPrefab;

    public GameObject CurrentEnemyInstance;


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(Instance);
        _currentMobIndex = 0;
        _currentBossIndex = 0;
        _currentEnemyPrefab = MobsToSpawn[_currentMobIndex];
        _currentBossPrefab = BossesToSpawn[_currentBossIndex];
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        CurrentEnemyInstance = Instantiate(_currentEnemyPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
    }
    public void SpawnBoss()
    {
        CurrentEnemyInstance = Instantiate(_currentBossPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
    }

    public void SetNextEnemy()
    {
        if (_currentMobIndex >= MobsToSpawn.Count - 1) { return; }
        _currentMobIndex++;
        _currentEnemyPrefab = MobsToSpawn[_currentMobIndex];
        ChangeEnemy();
    }

    public void SetPreviousEnemy()
    {
        if (_currentMobIndex <= 0) { return; }
        _currentMobIndex--;
        _currentEnemyPrefab = MobsToSpawn[_currentMobIndex];
        ChangeEnemy();
    }

    public void StartBossFight()
    {
        if (_currentBossIndex >= BossesToSpawn.Count) { return; }
        Destroy(CurrentEnemyInstance);
        SpawnBoss();
    }

    public void ChangeEnemy()
    {
        if (CurrentEnemyInstance == null)
        {
            return;
        }
        CurrentEnemyInstance.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(DelayRespawn());
    }

    public void SetNextBoss()
    {
        _currentBossIndex++;
        if (_currentBossIndex >= BossesToSpawn.Count) { Debug.Log("no more bosses you won the game"); return; }
        _currentBossPrefab = BossesToSpawn[_currentBossIndex];
    }

    IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(EnemySwapAnimationDelay);
        Destroy(CurrentEnemyInstance);
        Instance.SpawnEnemy();
    }
}

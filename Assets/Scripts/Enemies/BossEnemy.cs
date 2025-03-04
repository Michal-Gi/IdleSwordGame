using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : BaseEnemy
{
    [SerializeField]
    public float TimeToBeat;

    private float TimeLeft;

    private void Awake()
    {
        TimeLeft = TimeToBeat;
    }

    private void FixedUpdate()
    {
        TimeLeft -= Time.deltaTime;
        if( TimeLeft <= 0 ) {
            EnemyManager.Instance.ChangeEnemy();
        }
    }

    //TODO: on boss death unlock new map
}

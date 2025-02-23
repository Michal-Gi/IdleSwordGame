using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : BaseEnemy
{
    [SerializeField]
    public float TimeToBeat;
    public float TimeLeft;

    private void Awake()
    {
        TimeLeft = TimeToBeat;
    }

    private void FixedUpdate()
    {
        TimeLeft -= Time.deltaTime;
        if( TimeLeft <= 0 ) { 
            //TODO: change boss without receiving rewards
        }
    }

    //TODO: on boss death unlock new map
}

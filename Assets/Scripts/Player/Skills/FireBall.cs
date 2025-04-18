using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : BaseSkill
{
    private void Awake()
    {
        DamageType = DamageType.Fire;
    }
}

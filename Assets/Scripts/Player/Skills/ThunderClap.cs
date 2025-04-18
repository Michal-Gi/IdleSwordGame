using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderClap : BaseSkill
{
    private void Awake()
    {
        DamageType = DamageType.Thunder;
    }
}

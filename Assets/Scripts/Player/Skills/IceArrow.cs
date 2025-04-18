using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceArrow : BaseSkill
{
    private void Awake()
    {
        DamageType = DamageType.Cold;
    }
}

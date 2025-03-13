using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Gear : Item
{
    [SerializeField]
    public GearData GearData;

    private void Awake()
    {
        Name = GearData.Name;
    }
}

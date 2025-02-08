using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Gear : ScriptableObject
{
    [SerializeField]
    public string Name;
    [SerializeField]
    public float Damage;
    [SerializeField]
    public float Accuracy;
    [SerializeField]
    public GearType GearType;
}

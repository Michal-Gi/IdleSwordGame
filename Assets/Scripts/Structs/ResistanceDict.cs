using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResistanceDict
{
    [SerializeField]
    public ResistanceValue[] Resistances;

    public Dictionary<DamageType, float> ToDict() {
        Dictionary<DamageType, float> res = new();
        foreach(var resVal in Resistances)
        {
            res.Add(resVal.DamageType, resVal.Value);
        }
        return res;
    }

}

[Serializable]
public class ResistanceValue {
    [SerializeField]
    public float Value;

    [SerializeField]
    public DamageType DamageType;
}

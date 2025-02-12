using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public string Name;

    [SerializeField]
    protected float TimeToDie;

    public void DestroyOnClicked()
    {
        Destroy(gameObject);
    }

    public void FixedUpdate()
    {
        if (TimeToDie <= 0) {
            Destroy(gameObject);
        }
        TimeToDie-=Time.deltaTime;
    }

}

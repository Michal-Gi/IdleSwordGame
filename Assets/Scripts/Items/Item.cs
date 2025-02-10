using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public string Name;

    public void DestroyOnClicked()
    {
        Destroy(gameObject);
    }

}

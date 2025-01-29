using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BaseEnemy : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public HealthSystem _healthSystem;

    [SerializeField]
    public UnityEvent OnDeath;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
    }
}

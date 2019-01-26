using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField]
    protected float m_Value = 0f;

    public abstract void Apply(Player player);

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null)
        {
            Apply(player);
            GameObject.Destroy(gameObject);
        }
    }
}

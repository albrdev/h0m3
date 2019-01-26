using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;

    [SerializeField]
    Player m_PlayerPrefab;

    [SerializeField]
    Transform m_BSOD;

    public void ShowBSOD()
    {
        m_BSOD.gameObject.SetActive(true);
    }

    public void HideBSOD()
    {
        m_BSOD.gameObject.SetActive(false);
    }

    public void SpawnPlayer()
    {
        GameObject.Instantiate(m_PlayerPrefab, null, true);
    }

    private void Awake()
    {
        if(Instance != null)
            throw new System.Exception("Multiple objects of this type is not allowed");

        Instance = this;

        m_BSOD.Find("RestartButton").GetComponent<Button>().onClick.AddListener(SpawnPlayer);
    }

    private void Start()
    {
        SpawnPlayer();
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}

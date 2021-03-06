﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; private set; } = null;

    [SerializeField]
    private Transform m_Start = null;
    [SerializeField]
    private Transform m_End = null;
    [SerializeField]
    private float m_Duration = 5f * 60f; // 5min

    private float m_StartTime;

    public void Restart()
    {
        m_StartTime = UnityEngine.Time.time;
    }

    private void Awake()
    {
        if(Instance != null)
            throw new System.Exception("Multiple objects of this type is not allowed");

        Instance = this;
    }

    private void Start()
    {
        Restart();
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    private void Update()
    {
        float t = (UnityEngine.Time.time - m_StartTime) / m_Duration;
        if(t <= 1f)
        {
            float x = Mathf.Lerp(m_Start.position.x, m_End.position.x, t);
            float y = Mathf.Lerp(m_Start.position.y, m_End.position.y, t);
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}

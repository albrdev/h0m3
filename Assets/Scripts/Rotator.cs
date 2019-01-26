using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    protected Vector3 m_Rotation = Vector3.zero;

    protected virtual void Update()
    {
        transform.Rotate(m_Rotation * UnityEngine.Time.deltaTime);
    }
}

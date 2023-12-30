using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float m_x, m_y, m_z;

    private void OnEnable()
    {
        SingleUpdate.Instance.UpdateDelegate += OnUpdate;
    }

    private void OnDisable()
    {
        if (SingleUpdate.Instance != null)
            SingleUpdate.Instance.UpdateDelegate -= OnUpdate;
    }

    void OnUpdate()
    {
        Vector3 rotate = new Vector3(m_x, m_y, m_z) * Time.unscaledDeltaTime;

        transform.Rotate(rotate, Space.Self);
    }
}
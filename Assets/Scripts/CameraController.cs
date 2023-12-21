using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera m_mainCamera;
    [SerializeField] Mesh m_cameraMesh;
    [SerializeField] Transform m_playerTransform,
                               m_targetTransform;
    [SerializeField] float m_rotationSpeed, // по умолчанию: 2
                           m_smoothSpeed; // по умолчанию: 0.05

    internal Vector3 target,
                     offset;



    void OnEnable()
    {
        SingleUpdate.Instance.UpdateDelegate += OnUpdate;
        SingleUpdate.Instance.LateUpdateDelegate += OnLateUpdate;
    }

    void OnDisable()
    {
        if (SingleUpdate.Instance != null)
        {
            SingleUpdate.Instance.UpdateDelegate -= OnUpdate;
            SingleUpdate.Instance.LateUpdateDelegate -= OnLateUpdate;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawSphere(transform.position, 0.2f);
        Gizmos.DrawLine(transform.position, m_mainCamera.transform.position);
        Gizmos.DrawMesh(m_cameraMesh,
                        m_mainCamera.transform.position,
                        m_mainCamera.transform.rotation,
                        new Vector3(0.4f, 0.4f, 0.4f));

        if (m_targetTransform != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(gameObject.transform.position, m_playerTransform.position);
            Gizmos.DrawLine(gameObject.transform.position, m_targetTransform.position);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(m_targetTransform.transform.position, m_playerTransform.position);
        }
    }



    void OnUpdate()
    {
        if (Input.GetMouseButton(1))
            transform.Rotate(Vector3.up, Input.GetAxis(AxisTags.MOUSE_X) * m_rotationSpeed);
    }

    void OnLateUpdate()
    {
        if (m_targetTransform != null && m_playerTransform != null)
        {
            float distance = Vector3.Distance(m_playerTransform.position, m_targetTransform.position);

            target = GetCentralPosition(distance);
            transform.position = Vector3.Lerp(transform.position, target, m_smoothSpeed);

            offset = GetCameraDistance(distance);
            m_mainCamera.transform.localPosition = Vector3.Lerp(m_mainCamera.transform.localPosition, offset, m_smoothSpeed);
        }
    }



    Vector3 GetCameraDistance(float _distance)
    {
        if (_distance >= 3)
            return new Vector3(0, 0, -_distance - 2);
        else
            return new Vector3(0, 0, -5);
    }

    Vector3 GetCentralPosition(float _distance)
    {
        Vector3 direction_move = m_playerTransform.position - m_targetTransform.position;

        return m_playerTransform.position - direction_move.normalized * _distance / 2;
    }
}

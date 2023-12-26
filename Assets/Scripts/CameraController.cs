using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera m_main_camera;
    [SerializeField] Mesh m_camera_mesh;
    [SerializeField] Transform m_player_transform,
                               m_target_transform;
    [SerializeField] float m_smooth_speed = 0.05f; // по умолчанию: 0.05

    internal Vector3 target,
                     offset;



    void OnEnable()
    {
        SingleUpdate.Instance.LateUpdateDelegate += OnLateUpdate;
    }

    void OnDisable()
    {
        if (SingleUpdate.Instance != null)
        {
            SingleUpdate.Instance.LateUpdateDelegate -= OnLateUpdate;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawSphere(transform.position, 0.2f);
        Gizmos.DrawLine(transform.position, m_main_camera.transform.position);
        Gizmos.DrawMesh(m_camera_mesh,
                        m_main_camera.transform.position,
                        m_main_camera.transform.rotation,
                        new Vector3(0.4f, 0.4f, 0.4f));

        if (m_target_transform != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(gameObject.transform.position, m_player_transform.position);
            Gizmos.DrawLine(gameObject.transform.position, m_target_transform.position);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(m_target_transform.transform.position, m_player_transform.position);
        }
    }



    void OnLateUpdate()
    {
        if (m_target_transform != null && m_player_transform != null)
        {
            float distance = Vector3.Distance(m_player_transform.position, m_target_transform.position);

            target = GetCentralPosition(distance);
            transform.position = Vector3.Lerp(transform.position, target, m_smooth_speed);

            offset = GetCameraDistance(distance);
            m_main_camera.transform.localPosition = Vector3.Lerp(m_main_camera.transform.localPosition, offset, m_smooth_speed);
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
        Vector3 direction_move = m_player_transform.position - m_target_transform.position;

        return m_player_transform.position - direction_move.normalized * _distance / 2;
    }



    public void SetPlayerTransform(Transform transform)
    {
        m_player_transform = transform;
    }

    public void SetTargetTransform(Transform transform)
    {
        m_target_transform = transform;
    }
}

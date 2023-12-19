using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera m_mainCamera;
    [SerializeField] float m_rotationSpeed;
    [SerializeField] Mesh m_cameraMesh;



    void OnEnable()
    {
        SingleUpdate.Instance.UpdateDelegate += OnUpdate;
    }

    void OnDisable()
    {
        if (SingleUpdate.Instance != null)
            SingleUpdate.Instance.UpdateDelegate -= OnUpdate;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawSphere(gameObject.transform.position, 0.4f);
        Gizmos.DrawLine(gameObject.transform.position, m_mainCamera.transform.position);
        Gizmos.DrawMesh(m_cameraMesh, m_mainCamera.transform.position, m_mainCamera.transform.rotation, new Vector3(0.4f, 0.4f, 0.4f));
    }



    void OnUpdate()
    {
        if (Input.GetMouseButton(1))
            gameObject.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * m_rotationSpeed);
    }
}

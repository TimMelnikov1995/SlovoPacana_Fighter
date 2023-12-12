using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera m_mainCamera;
    [SerializeField] float m_rotationSpeed;



    private void OnEnable()
    {
        SingleUpdate.Instance.UpdateDelegate += OnUpdate;
    }

    private void OnDisable()
    {
        if (SingleUpdate.Instance != null)
            SingleUpdate.Instance.UpdateDelegate -= OnUpdate;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(gameObject.transform.position, 0.5f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(gameObject.transform.position, m_mainCamera.transform.position);
    }



    void OnUpdate()
    {
        if (Input.GetMouseButton(1))
            gameObject.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * m_rotationSpeed);
    }
}

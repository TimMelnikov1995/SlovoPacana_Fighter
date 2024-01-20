using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _playerTransform,
                               _targetTransform;
    [Space]
    //[SerializeField] Camera _mainCamera;
    [SerializeField] float _smoothSpeed = 5f;
    //[Space]
    [SerializeField] float _minDesiredDistanceTogether = 5;
    [SerializeField] float _minDesiredDistanceAlone = 10;
    [SerializeField] float _distanceOffset = 2;

    Transform _cameraTransform;
    Mesh _cameraMesh;

    //private Transform CameraTransform => _mainCamera.transform;



    void Awake()
    {
        if (_cameraTransform == null)
            _cameraTransform = transform.GetComponentInChildren<Camera>().transform;
    }

    void OnDrawGizmos()
    {
        if (_cameraTransform == null)
            _cameraTransform = transform.GetComponentInChildren<Camera>().transform;

        if (_cameraMesh == null)
            _cameraMesh = Resources.Load<Mesh>("Meshes/camera");

        Gizmos.color = Color.white;

        Gizmos.DrawSphere(gameObject.transform.position, 0.4f);
        Gizmos.DrawLine(gameObject.transform.position, _cameraTransform.position);
        Gizmos.DrawMesh(_cameraMesh, _cameraTransform.position, _cameraTransform.rotation, new Vector3(0.4f, 0.4f, 0.4f));

        if (_playerTransform != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, _playerTransform.position);

            if (_targetTransform != null)
            {
                Gizmos.DrawLine(transform.position, _targetTransform.position);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(_playerTransform.position, _targetTransform.position);
            }
        }
    }

    void LateUpdate()
    {
        float speed = _smoothSpeed * Time.deltaTime;

        _cameraTransform.localRotation = Quaternion.Slerp(_cameraTransform.localRotation,
                                                               new Quaternion(0, 0, 0, 1),
                                                               speed);

        if (_playerTransform != null)
        {
            Vector3 target = _playerTransform.position,
                    offset = new Vector3(0, 0, -_minDesiredDistanceAlone);

            if (_targetTransform != null)
            {
                float distance = Vector3.Distance(_playerTransform.position, _targetTransform.position);

                target = GetCentralPosition(distance);
                offset = GetCameraDistance(distance);
            }

            transform.position = Vector3.Lerp(transform.position, target, speed);
            _cameraTransform.localPosition = Vector3.Lerp(_cameraTransform.localPosition, offset, speed);
        }
    }



    Vector3 GetCameraDistance(float _distance)
    {
        if (_distance >= _minDesiredDistanceTogether - _distanceOffset)
            return new Vector3(0, 0, -_distance - _distanceOffset);
        else
            return new Vector3(0, 0, -_minDesiredDistanceTogether);
    }

    Vector3 GetCentralPosition(float _distance)
    {
        Vector3 direction_move = _playerTransform.position - _targetTransform.position;

        return _playerTransform.position - direction_move.normalized * _distance / 2;
    }

    public void SetPlayerTransform(Transform transform)
    {
        _playerTransform = transform;
    }

    public void SetTargetTransform(Transform transform)
    {
        _targetTransform = transform;
    }
}

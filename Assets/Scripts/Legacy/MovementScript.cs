using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Vector3 _normal;

    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = Project(direction);
        Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);

        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    public Vector3 Project(Vector3 direction)
    {
        return direction - (_normal * Vector3.Dot(direction, _normal));
    }



    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.localPosition, transform.localPosition + (_normal * 2));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.localPosition, transform.localPosition + Project(transform.forward));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            other.gameObject.SetActive(false);
        }

        //print(other.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _normal = collision.GetContact(0).normal;
    }
}
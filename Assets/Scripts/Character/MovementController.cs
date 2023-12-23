using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] float m_speed;

    Rigidbody _rigidbody;
    Vector3 _normal;



    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }



    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = Project(direction);
        Vector3 offset = directionAlongSurface * (m_speed * Time.deltaTime);

        _rigidbody.MovePosition(_rigidbody.position + offset);
        //_rigidbody.AddForce(_rigidbody.position + offset);
        //_rigidbody.AddRelativeForce(_rigidbody.position + offset);
    }

    public Vector3 Project(Vector3 direction)
    {
        return direction - (_normal * Vector3.Dot(direction, _normal));
    }

    /*private void OnDrawGizmos()
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
    }*/
}
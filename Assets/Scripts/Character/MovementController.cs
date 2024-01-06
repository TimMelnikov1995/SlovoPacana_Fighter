using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] FightingCharacterController m_character_controller;
    [SerializeField] CharacterController m_characterController;
    [SerializeField] Rigidbody _rigidbody;
    [Space]
    [SerializeField] float m_speed;

    Vector3 _normal;



    void Start()
    {

    }



    public void Move(Vector3 direction)
    {
        if (m_character_controller.CharacterState == CharacterState.Moving)
        {
            Vector3 directionAlongSurface = Project(direction);
            Vector3 offset = directionAlongSurface * (m_speed * Time.deltaTime);

            _rigidbody.MovePosition(_rigidbody.position + offset);
            //_rigidbody.AddForce(_rigidbody.position + offset);
            //_rigidbody.AddRelativeForce(_rigidbody.position + offset);
        }
    }

    public Vector3 Project(Vector3 direction)
    {
        return direction - (_normal * Vector3.Dot(direction, _normal));
    }

    public void Jump()
    {
        _rigidbody.AddForce(_normal + (Vector3.up * 5));
    }

    public void Crouch()
    {

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
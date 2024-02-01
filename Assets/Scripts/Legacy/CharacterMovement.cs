using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float m_x_speed = 3f;
    [SerializeField] float m_z_speed = 1.5f;

    Rigidbody _rigidbody;
    float _yRotation = 90f;

    public void DetectMovement(float movement_x = 0, float movement_z = 0)
    {
        Vector3 velocity = new Vector3(movement_x * m_x_speed,
                                      _rigidbody.velocity.y,
                                      movement_z * m_z_speed);

        _rigidbody.velocity = velocity;
    }

    public void RotatePlayer(float movement)
    {
        if (movement > 0)
            _yRotation = 90f;
        if (movement < 0)
            _yRotation = -90f;

        transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
    }



    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}

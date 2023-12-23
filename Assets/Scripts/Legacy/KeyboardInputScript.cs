using UnityEngine;

public class KeyboardInputScript : MonoBehaviour
{
    PhysicsMovement _movement;
    CharacterAnimation _characterAnimation;

    float _horizontal;
    float _vertical;

    void FixedUpdate()
    {
        _horizontal = Input.GetAxis(AxisTags.HORIZONTAL_AXIS);
        //_vertical = Input.GetAxis(AxisTags.VERTICAL_AXIS);

        _movement.Move(new Vector3(_horizontal, 0, 0));
    }

    void Start()
    {
        _movement = GetComponent<PhysicsMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}

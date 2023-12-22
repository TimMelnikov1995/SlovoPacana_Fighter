using UnityEngine;

public class KeyboardInputScript : MonoBehaviour
{
    private PhysicsMovement _movement;

    private float _horizontal;
    private float _vertical;

    private void FixedUpdate()
    {
        _horizontal = Input.GetAxis(AxisTags.HORIZONTAL_AXIS);
        _vertical = Input.GetAxis(AxisTags.VERTICAL_AXIS);

        _movement.Move(new Vector3(_horizontal, 0, _vertical));
    }

    private void Start()
    {
        _movement = GetComponent<PhysicsMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}

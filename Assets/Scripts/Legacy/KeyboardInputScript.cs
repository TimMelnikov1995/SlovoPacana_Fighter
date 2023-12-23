using UnityEngine;

public class KeyboardInputScript : MonoBehaviour
{
    CharacterAnimation _characterAnimation;
    MovementController _movement;



    void Start()
    {
        _movement = GetComponent<MovementController>();
    }

    void Update()
    {
        _movement.Move(new Vector3(Input.GetAxis(AxisTags.HORIZONTAL_AXIS), 0, 0));
    }
}

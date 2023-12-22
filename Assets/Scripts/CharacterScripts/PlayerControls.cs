using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] Collider _colliderFullHeight;
    [SerializeField] Collider _colliderOnCrouch;

    HealthSystem _healthSystem;
    CharacterMovement _characterMovement;
    CharacterAnimation _characterAnimation;

    float _xMovement, _zMovement;

    bool CheckCrouch(bool is_pressed)
    {
        _colliderOnCrouch.enabled = is_pressed;
        _colliderFullHeight.enabled = !is_pressed;
        _characterAnimation.SetAnimationBoolByName(AnimationTags.CROUCH_ANIMATION, is_pressed);

        return is_pressed;
    }

    bool CheckBlock(bool is_pressed)
    {
        _healthSystem._inBlockingState = is_pressed;
        _characterAnimation.SetAnimationBoolByName(AnimationTags.BLOCK_ANIMATION, is_pressed);

        return is_pressed;
    }



    void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _characterMovement = GetComponent<CharacterMovement>();
        _characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }

    void Update()
    {
        if (!_healthSystem._isDead)
        {
            _xMovement = Input.GetAxisRaw(AxisTags.HORIZONTAL_AXIS);
            //_zMovement = Input.GetAxisRaw(AxisTags.VERTICAL_AXIS);

            if (!Input.GetKey(KeyCode.C)
            && !Input.GetKey(KeyCode.B))
                _characterMovement.DetectMovement(_xMovement, _zMovement);

            _characterAnimation.MoveForward(false);
            _characterMovement.RotatePlayer(_xMovement);

            if(!CheckCrouch(Input.GetKey(KeyCode.C))
            && !CheckBlock(Input.GetKey(KeyCode.B)))
                if (_xMovement != 0 || _zMovement != 0)
                    _characterAnimation.MoveForward(true);
        }
    }
}

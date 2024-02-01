using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] Collider m_collider_full_height;
    [SerializeField] Collider m_collider_on_crouch;

    HealthSystem _healthSystem;
    CharacterMovement _characterMovement;
    CharacterAnimation _characterAnimation;

    float _xMovement, _zMovement;

    bool CheckCrouch(bool is_pressed)
    {
        //_colliderOnCrouch.enabled = is_pressed;
        //_colliderFullHeight.enabled = !is_pressed;
        
        //_characterAnimation.SetAnimationBoolByName(AnimationTags.CROUCH_ANIMATION, is_pressed);
        //_characterAnimation.ChangeLayer(is_pressed);

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

    }

    void FixedUpdate()
    {
        if (!_healthSystem._isDead)
        {
            _xMovement = Input.GetAxisRaw(AxisTags.HORIZONTAL_AXIS);
            //_zMovement = Input.GetAxisRaw(AxisTags.VERTICAL_AXIS);

            if (!Input.GetKey(KeyCode.S)
            && !Input.GetKey(KeyCode.B))
                _characterMovement.DetectMovement(_xMovement, _zMovement);

            _characterAnimation.HorizontalMove(0);
            //_characterMovement.RotatePlayer(_xMovement);

            /*if (!CheckCrouch(Input.GetKey(KeyCode.S))
            && !CheckBlock(Input.GetKey(KeyCode.B)))
            {
                if(transform.rotation.eulerAngles.y < 180)
                    _characterAnimation.Move(_xMovement);
                else
                    _characterAnimation.Move(-_xMovement);
            }*/
        }
    }
}

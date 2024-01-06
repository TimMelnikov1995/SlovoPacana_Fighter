using UnityEngine;

public class CS_Moving : CFSM_CCC_State
{
    protected readonly float _speed;



    public CS_Moving(Character_FSM state_machine, CharacterController character_controller, Transform character_transform, float speed) : base(state_machine, character_controller, character_transform)
    {
        _speed = speed;
    }



    public override void Update()
    {
        Vector2 input_direction = ReadInput();

        if (input_direction.sqrMagnitude != 0)
            _stateMachine.SetState<CS_Idle>();

        if (PlayerInput.Instance.jump)
            _stateMachine.SetState<CS_Jumping>();

        //if (Input.GetKeyDown(KeyCode.LeftShift))
            //_stateMachine.SetState<CS_Running>();

        Move(input_direction);
    }



    protected Vector2 ReadInput()
    {
        float horizontal = PlayerInput.Instance.horizontal_move;
        //float vertical = PlayerInput.Instance.vertical_move;

        return new Vector2(horizontal, 0);
    }



    protected virtual void Move(Vector2 input_direction)
    {
        Vector3 moving_direction = _characterTransform.forward * input_direction.x;
                                 //+ _characterTransform.right * input_direction.x;
        moving_direction *= _speed * Time.deltaTime;

        _characterController.Move(moving_direction);
    }
}

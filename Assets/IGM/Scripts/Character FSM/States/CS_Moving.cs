using UnityEngine;

public class CS_Moving : CFSM_BaseState
{
    protected readonly float _speed;



    public CS_Moving(Character_FSM state_machine, float speed) : base(state_machine)
    {
        _speed = speed;
    }



    public override void Enter()
    {
        //Debug.Log("Moving state: [ENTER]");
    }

    public override void Exit()
    {
        //Debug.Log("Moving state: [EXIT]");
    }

    public override void Update()
    {
        Vector2 input_direction = ReadInput();

        if (input_direction.sqrMagnitude == 0)
            _stateMachine.SetState<CS_Idle>();

        if (_stateMachine.characterInput.Jump)
            _stateMachine.SetState<CS_Jumping>();

        //if (Input.GetKeyDown(KeyCode.LeftShift))
            //_stateMachine.SetState<CS_Running>();

        Move(input_direction);
    }



    protected Vector2 ReadInput()
    {
        float horizontal = _stateMachine.characterInput.Horizontal_Move;
        //float vertical = PlayerInput.vertical_move;

        return new Vector2(horizontal, 0);
    }



    protected virtual void Move(Vector2 input_direction)
    {
        Vector3 moving_direction = _stateMachine.characterController.transform.forward * input_direction.x;
                                 //+ _characterTransform.right * input_direction.x;
        moving_direction *= _speed * Time.deltaTime;

        _stateMachine.characterController.Move(moving_direction);
    }
}
